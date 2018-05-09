using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MarshfieldTimeClock_V1._1
{
    public partial class TimeClock : System.Web.UI.Page
    {
        DBMaster db = new DBMaster();
        bool buttonsEnabled = true;
        Employee myEmployee = new Employee(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            
            /// populate users roles
             if (!IsPostBack)
            {
                try
                {
                    chkBxLunch.Visible = false;
                    myEmployee = (Employee)Session["Employee"];
                    if (myEmployee.Roles.Count == 0 || myEmployee.WorkID.Count == 0)
                    {
                        SqlDataReader reader = db.getSpReader("spGetEmployeeRolls", "@EmployeeID", myEmployee.EmployeeID);
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.GetName(i) == "Role")
                                {
                                    myEmployee.Roles.Add(reader[i].ToString());
                                }
                                else if (reader.GetName(i) == "WorkID")
                                {
                                    myEmployee.WorkID.Add(reader[i].ToString());
                                }
                            }
                        }
                        db.closeConnection();
                    }
                    foreach(string role in myEmployee.Roles)
                    {
                        drpDwnWorkId.Items.Add(role);
                        if (role == "Paraprofessional")
                        {
                            chkBxLunch.Visible = true;
                        }
                    }
                    if (drpDwnWorkId.Items.Count < 2)
                    {
                        btnChangeRole.Visible = false;
                    }

                    txtBxDisplayTime.Text = DateTime.Now.ToString("t");
                    txtBxDisplayDay.Text = DateTime.Now.ToString("D");

                    if (buttonsEnabled)
                    {
                        btnClockIn.Enabled = true;
                        btnClockOut.Enabled = true;
                    }
                    else
                    {
                        btnClockIn.Enabled = false;
                        btnClockOut.Enabled = false;
                    }
                
                }
                catch(Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine("######### TIMECLOCK Page_Load():  " + exc.Message);
                    lblAlert.Text = "Error could not complete Page_Load. Please inform system administrator. ";
                    lblTimeClockStatus.Text = "Error Message: " + exc.Message;
                }
               
            }
        }

        protected void drpDwnWorkId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            buttonsEnabled = true;
        }

        /// <summary>
        /// Clock in Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClockIn_Click(object sender, EventArgs e)
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                lblAlert.Text = "";
                lblTimeClockStatus.Text = "";
                if (isClockedIn(sender, e) == false) // not currently clocked in, or missing punch from past day~~ allow clock in
                {
                    string time = DateTime.Now.ToString("t");
                    string date = DateTime.Now.ToString("D");
                    if(myEmployee.FogottenClockout != DateTime.MinValue)
                    {
                        lblAlert.Text = ("You are missing your clock out from " + myEmployee.FogottenClockout.Date.ToShortDateString() + ". Please see managment.");
                    }
                    NewRecordInsert(sender, e);
                    lblTimeClockStatus.Text = ("You have clocked in at " + time + " " + date);
                
                }
                else  // clocked in from today ~~ alert and do nothing
                {
                    lblAlert.Text = ("You have already clocked in today");
                   //do nothing
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK btnClockIn_Click():  " + exc.Message);
                lblAlert.Text = "Error could not complete clock in. Please inform system administrator. ";
                lblTimeClockStatus.Text = "Error Message: " + exc.Message;
            }

        }

        /// <summary>
        /// Clock out Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClockOut_Click(object sender, EventArgs e)
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                lblAlert.Text = "";
                lblTimeClockStatus.Text = "";
                if (isClockedIn(sender, e) == true)    // clocked in from today
                {
                    string time = DateTime.Now.ToString("t");
                    string date = DateTime.Now.ToString("D");
                    lblTimeClockStatus.Text = ("You have clocked out at " + time + " " + date);
                    RecordClockoutUpdate(sender, e);
                }
                else
                {
                    lblAlert.Text = ("You are not clocked in Today");
                    // do nothing
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK btnClockOut_Click():  " + exc.Message);
                lblAlert.Text = "Error could not complete clock out. Please inform system administrator. ";
                lblTimeClockStatus.Text = "Error Message: " + exc.Message;
            }

        }

        protected void btnChangeRole_Click(object sender, EventArgs e) /// ############# could cause problem if someone checks meal punch and then changes rolls!!! need to fix!!!
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                lblAlert.Text = "";
                lblTimeClockStatus.Text = "";
                if (isClockedIn(sender, e) == true)    // clocked in from today
                {
                    if(isNewRole(sender,e) == true)    // new role can change roles
                    {
                        RecordClockoutUpdate(sender, e);
                        NewRecordInsert(sender, e);
                        lblTimeClockStatus.Text = ("Role changed to " + drpDwnWorkId.SelectedItem+".");

                    }
                    else                                // same role as before, do not change rolls
                    {
                        lblAlert.Text = ("You are already clocked in as a " + drpDwnWorkId.SelectedItem.Text + ". Please select a different role.");
                    }

                }
                else                                    // not clocked in
                {
                    lblAlert.Text = ("You are not clocked in Today");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK btnChangeRole_Click():  " + exc.Message);
                lblAlert.Text = "Error could not complete role change. Please inform system administrator. ";
                lblTimeClockStatus.Text ="Error Message: " + exc.Message;
                //throw;
            }

        }
        /// <summary>
        /// runs sql clockout db update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RecordClockoutUpdate(object sender, EventArgs e)
        {
            try
            {
                string checkedBox = "0";
                if(chkBxLunch.Checked == true)
                {
                    checkedBox = "1";
                }
                myEmployee = (Employee)Session["Employee"];
                db.updateRecord(DateTime.Now.ToString("HH:mm:ss"), DateTime.Now.ToString("MM/dd/yyyy"),checkedBox, myEmployee.EmployeeID);
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK RecordClockoutUpdate():  " + exc.Message);
                throw;
            }

        }
       /// <summary>
       /// runs sql clock in insert
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       protected void NewRecordInsert(object sender, EventArgs e)
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                db.insertNewRecord(myEmployee.WorkID[drpDwnWorkId.SelectedIndex], myEmployee.EmployeeID,myEmployee.Roles[drpDwnWorkId.SelectedIndex], DateTime.Now.ToString("HH:mm:ss"), DateTime.Now.ToString("MM/dd/yyyy"));
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK NewRecordInsert():  " + exc.Message);
                throw;
            }

        }
        /// <summary>
        /// checks if selected roll is different from current role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool isNewRole(object sender, EventArgs e)
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                string workId = "";
                SqlDataReader reader = db.getSpReader("spCheckCurrentRole", "@EmployeeID", myEmployee.EmployeeID);
                while (reader.Read())
                {
                    workId = reader[0].ToString();
                }
                if (myEmployee.WorkID[drpDwnWorkId.SelectedIndex] != workId) // if workid with index same as dropdown != workid
                {
                    return true;
                }
                else                                                        // same work id as current 
                {
                    return false;
                }

            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK isNewRole():  " + exc.Message);
                throw;
            }

        }
        /// <summary>
        /// checks employee clocked in status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool isClockedIn(object sender, EventArgs e)
        {
            try
            {
                myEmployee = (Employee)Session["Employee"];
                myEmployee.FogottenClockout = DateTime.MinValue;
                SqlDataReader reader = db.getSpReader("spCheckClockedIN", "@EmployeeID", myEmployee.EmployeeID);

                while (reader.Read())
                {

                    DateTime dateIn = Convert.ToDateTime(reader[0]);
                    if (reader[1] != DBNull.Value)
                    {
                        //clocked out
                        return false;
                    }
                    else
                    {
                        // clocked in or missing clock out
                        myEmployee.FogottenClockout = dateIn;
                        if(dateIn.Date == DateTime.Now.Date)
                        {
                            // considered clocked in 
                            return true;
                        }
                        else
                        {
                           // missing clock out from previous day, show as clocked out so employee can clock in for today
                            return false;
                        }
                    }
                }
                return false;
                //throw new Exception("TimeClock, isClockedIn(), Line: 272. reader returned no data from database.");

            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### TIMECLOCK isClockedIn():  " + exc.Message);
                throw;
            }
        }



    }// end class
}