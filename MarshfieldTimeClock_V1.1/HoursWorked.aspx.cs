using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;




namespace MarshfieldTimeClock_V1._1
{
    public partial class HoursWorked : System.Web.UI.Page
    {
        DBMaster db = new DBMaster();
        Employee myEmployee = new Employee();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            lblAlert.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    myEmployee = (Employee)Session["Employee"];
                    if (myEmployee.DaysWorked.Count == 0 || myEmployee.HoursWorked.Count == 0)
                    {
                        SqlDataReader reader = db.getSpReader("spGetMonthHours", "@EmployeeID", myEmployee.EmployeeID);
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.GetName(i) == "DateIn")
                                {
                                    myEmployee.DaysWorked.Add(Convert.ToDateTime(reader[i].ToString()));
                                }
                                else if (reader.GetName(i) == "Total_Time")
                                {
                                    myEmployee.HoursWorked.Add(Convert.ToDouble(reader[i].ToString()));
                                }
                            }
                        }
                        db.closeConnection();
                    }
                    populateTable(sender, e);

                    if (is4WeekMonth(sender, e) == true)
                    {
                        set4WeekMonth(sender, e);
                    }
                    else if (is6WeekMonth(sender, e) == true)
                    {
                        // 6 week month no need to set
                    }
                    else
                    {
                        set5WeekMonth(sender, e);
                    }
                }
                catch(Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine("######### HOURSWORKED Page_Load():  " + exc.Message);
                    lblAlert.Visible = true;
                    lblAlert.Text = "Error could not complete Page_Load. Please inform system administrator. Error Message: " + exc.Message;
                }
            }// end ispostback
        }

         /// <summary>
        /// test data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void populateTable( object sender, EventArgs e)
        {
            try
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);


                // sets starting day of month
                int offset = getFirstDayOfMonth(firstDayOfMonth, sender, e);

                for (int i = 0; i < myEmployee.HoursWorked.Count(); i++)
                {
                    int day = myEmployee.DaysWorked[i].Day;
                    day = day + offset;

                    switch (day) {
                        case 1:
                             Wk1Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 2:
                            Wk1Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 3:
                            Wk1Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 4:
                            Wk1Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 5:
                            Wk1Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 6:
                            Wk1Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 7:
                            Wk1Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;

                        case 8:
                            Wk2Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 9:
                            Wk2Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 10:
                            Wk2Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 11:
                            Wk2Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 12:
                            Wk2Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 13:
                            Wk2Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 14:
                            Wk2Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;

                        case 15:
                            Wk3Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 16:
                            Wk3Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 17:
                            Wk3Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 18:
                            Wk3Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 19:
                            Wk3Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 20:
                            Wk3Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 21:
                            Wk3Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;

                        case 22:
                            Wk4Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 23:
                            Wk4Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 24:
                            Wk4Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 25:
                            Wk4Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 26:
                            Wk4Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 27:
                            Wk4Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 28:
                            Wk4Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;

                        case 29:
                            Wk5Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 30:
                            Wk5Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 31:
                            Wk5Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 32:
                            Wk5Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 33:
                            Wk5Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 34:
                            Wk5Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 35:
                            Wk5Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;

                        case 36:
                            Wk6Sun.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 37:
                            Wk6Mon.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 38:
                            Wk6Tues.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 39:
                            Wk6Wed.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 40:
                            Wk6Thur.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 41:
                            Wk6Fri.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                        case 42:
                            Wk6Sat.Text = setDayHours(myEmployee.HoursWorked[i], sender, e);
                            break;
                    }
                }

                calculateTotals(sender, e);
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED populateTable():  " + exc.Message);
                throw;
            }


            
        }
        protected string setDayHours(double hours, object sender, EventArgs e)
        {
            try
            {
                return String.Format("{0:0.00}", hours);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED setDayHours():  " + exc.Message);
                throw;
            }
           
        }
        protected int getFirstDayOfMonth(DateTime firstDayOfMonth, object sender, EventArgs e)
        {
            try
            {
                switch (firstDayOfMonth.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return 0;
                    case DayOfWeek.Monday:
                        return 1;
                    case DayOfWeek.Tuesday:
                        return 2;
                    case DayOfWeek.Wednesday:
                        return 3;
                    case DayOfWeek.Thursday:
                        return 4;
                    case DayOfWeek.Friday:
                        return 5;
                    case DayOfWeek.Saturday:
                        return 6;
                }
                throw new Exception();
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED getFirstDayOfMonth():  " + exc.Message);
                throw;
            }
        }

        /// <summary>
        /// check if month is feb and if the 1st is on sunday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool is4WeekMonth(object sender, EventArgs e)
        {
            try
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                if (now.Month == 2)
                {
                   var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                   if(firstDayOfMonth.DayOfWeek == DayOfWeek.Sunday)
                    { 
                        return true;
                    }
                }
                return false;
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED is4WeekMonth():  " + exc.Message);
                throw;
            }

        }

        /// <summary>
        /// returns if current month has 6 weeks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool is6WeekMonth(object sender, EventArgs e)
        {
            try
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                if ((daysInMonth == 30 && firstDayOfMonth.DayOfWeek == DayOfWeek.Saturday) || (daysInMonth == 31 && (firstDayOfMonth.DayOfWeek == DayOfWeek.Friday || firstDayOfMonth.DayOfWeek == DayOfWeek.Saturday))){
                    return true;
                }
                return false;
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED is6WeekMonth():  " + exc.Message);
                throw;
            }
        }
  

        /// <summary>
        /// Sets Visual table to show 4 week month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        /// 
        protected void set4WeekMonth(object sender, EventArgs e)
        {
            try
            {
                wk5Header.Visible = false;
                Wk5Sun.Visible = false;
                Wk5Mon.Visible = false;
                Wk5Tues.Visible = false;
                Wk5Wed.Visible = false;
                Wk5Thur.Visible = false;
                Wk5Fri.Visible = false;
                Wk5Sat.Visible = false;
                Wk5Total.Visible = false;

                wk6Header.Visible = false;
                Wk6Sun.Visible = false;
                Wk6Mon.Visible = false;
                Wk6Tues.Visible = false;
                Wk6Wed.Visible = false;
                Wk6Thur.Visible = false;
                Wk6Fri.Visible = false;
                Wk6Sat.Visible = false;
                Wk6Total.Visible = false;
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED set4WeekMonth():  " + exc.Message);
                throw;
            }
        }
        /// <summary>
        /// Sets visual table to show 5 week month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void set5WeekMonth(object sender, EventArgs e)
        {
            try
            {
                wk6Header.Visible = false;
                Wk6Sun.Visible = false;
                Wk6Mon.Visible = false;
                Wk6Tues.Visible = false;
                Wk6Wed.Visible = false;
                Wk6Thur.Visible = false;
                Wk6Fri.Visible = false;
                Wk6Sat.Visible = false;
                Wk6Total.Visible = false;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED set5WeekMonth():  " + exc.Message);
                throw;
            }
        }
        /// <summary>
        /// Calculates totals for table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calculateTotals(object sender, EventArgs e)
        {
            try
            {
                double wk1Hours = 0;
                double wk2Hours = 0;
                double wk3Hours = 0;
                double wk4Hours = 0;
                double wk5Hours = 0;
                double wk6Hours = 0;
                wk1Hours += Convert.ToDouble(Wk1Sun.Text);
                wk1Hours += Convert.ToDouble(Wk1Mon.Text);
                wk1Hours += Convert.ToDouble(Wk1Tues.Text);
                wk1Hours += Convert.ToDouble(Wk1Wed.Text);
                wk1Hours += Convert.ToDouble(Wk1Thur.Text);
                wk1Hours += Convert.ToDouble(Wk1Fri.Text);
                wk1Hours += Convert.ToDouble(Wk1Sat.Text);
                Wk1Total.Text = wk1Hours.ToString();

                wk2Hours += Convert.ToDouble(Wk2Sun.Text);
                wk2Hours += Convert.ToDouble(Wk2Mon.Text);
                wk2Hours += Convert.ToDouble(Wk2Tues.Text);
                wk2Hours += Convert.ToDouble(Wk2Wed.Text);
                wk2Hours += Convert.ToDouble(Wk2Thur.Text);
                wk2Hours += Convert.ToDouble(Wk2Fri.Text);
                wk2Hours += Convert.ToDouble(Wk2Sat.Text);
                Wk2Total.Text = wk2Hours.ToString();

                wk3Hours += Convert.ToDouble(Wk3Sun.Text);
                wk3Hours += Convert.ToDouble(Wk3Mon.Text);
                wk3Hours += Convert.ToDouble(Wk3Tues.Text);
                wk3Hours += Convert.ToDouble(Wk3Wed.Text);
                wk3Hours += Convert.ToDouble(Wk3Thur.Text);
                wk3Hours += Convert.ToDouble(Wk3Fri.Text);
                wk3Hours += Convert.ToDouble(Wk3Sat.Text);
                Wk3Total.Text = wk3Hours.ToString();

                wk4Hours += Convert.ToDouble(Wk4Sun.Text);
                wk4Hours += Convert.ToDouble(Wk4Mon.Text);
                wk4Hours += Convert.ToDouble(Wk4Tues.Text);
                wk4Hours += Convert.ToDouble(Wk4Wed.Text);
                wk4Hours += Convert.ToDouble(Wk4Thur.Text);
                wk4Hours += Convert.ToDouble(Wk4Fri.Text);
                wk4Hours += Convert.ToDouble(Wk4Sat.Text);
                Wk4Total.Text = wk4Hours.ToString();

                wk5Hours += Convert.ToDouble(Wk5Sun.Text);
                wk5Hours += Convert.ToDouble(Wk5Mon.Text);
                wk5Hours += Convert.ToDouble(Wk5Tues.Text);
                wk5Hours += Convert.ToDouble(Wk5Wed.Text);
                wk5Hours += Convert.ToDouble(Wk5Thur.Text);
                wk5Hours += Convert.ToDouble(Wk5Fri.Text);
                wk5Hours += Convert.ToDouble(Wk5Sat.Text);
                Wk5Total.Text = wk5Hours.ToString();

                wk6Hours += Convert.ToDouble(Wk6Sun.Text);
                wk6Hours += Convert.ToDouble(Wk6Mon.Text);
                wk6Hours += Convert.ToDouble(Wk6Tues.Text);
                wk6Hours += Convert.ToDouble(Wk6Wed.Text);
                wk6Hours += Convert.ToDouble(Wk6Thur.Text);
                wk6Hours += Convert.ToDouble(Wk6Fri.Text);
                wk6Hours += Convert.ToDouble(Wk6Sat.Text);
                Wk6Total.Text = wk6Hours.ToString();

                FinalTotal.Text = Convert.ToString(wk1Hours + wk2Hours + wk3Hours + wk4Hours + wk5Hours + wk6Hours);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### HOURSWORKED calculateTotals():  " + exc.Message);
                throw;
            }
        }
    }//end class
}