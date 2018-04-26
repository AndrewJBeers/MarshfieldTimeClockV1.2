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
        protected void Page_Load(object sender, EventArgs e)
        {
            populateTable(sender, e);
            if(is4WeekMonth(sender, e) == true)
            {
                set4WeekMonth(sender, e);
            }
            else if(is6WeekMonth(sender, e) == true)
            {
                // 6 week month no need to set
            }else
            {
                set5WeekMonth(sender, e);
            }

            Employee employee = new Employee();
            DBMaster dbMaster = new DBMaster();
            SqlDataReader reader = dbMaster.getReader("Select * From Log_Table");
            int i = 0;
            while (reader.Read())
            {
                employee.RolesDescription.Add(reader.ToString());
            }
            dbMaster.closeConnection();
            foreach (string stuff in employee.RolesDescription)
            {
                Console.WriteLine(stuff);
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// test data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void populateTable(object sender, EventArgs e)
        {
            Wk1Sun.Text = "0";
            Wk1Mon.Text = "5";
            Wk1Tues.Text = "0";
            Wk1Wed.Text = "8";
            Wk1Thur.Text = "0";
            Wk1Fri.Text = "4";
            Wk1Sat.Text = "0";

            Wk2Sun.Text = "7";
            Wk2Mon.Text = "0";
            Wk2Tues.Text = "3";
            Wk2Wed.Text = "4";
            Wk2Thur.Text = "0";
            Wk2Fri.Text = "0";
            Wk2Sat.Text = "0";

            Wk3Sun.Text = "0";
            Wk3Mon.Text = "0";
            Wk3Tues.Text = "0";
            Wk3Wed.Text = "0";
            Wk3Thur.Text = "0";
            Wk3Fri.Text = "0";
            Wk3Sat.Text = "0";

            Wk4Sun.Text = "0";
            Wk4Mon.Text = "0";
            Wk4Tues.Text = "0";
            Wk4Wed.Text = "0";
            Wk4Thur.Text = "0";
            Wk4Fri.Text = "0";
            Wk4Sat.Text = "0";

            Wk5Sun.Text = "0";
            Wk5Mon.Text = "0";
            Wk5Tues.Text = "0";
            Wk5Wed.Text = "0";
            Wk5Thur.Text = "0";
            Wk5Fri.Text = "0";
            Wk5Sat.Text = "0";

            Wk6Sun.Text = "0";
            Wk6Mon.Text = "0";
            Wk6Tues.Text = "0";
            Wk6Wed.Text = "0";
            Wk6Thur.Text = "0";
            Wk6Fri.Text = "0";
            Wk6Sat.Text = "0";



            calculateTotals(sender, e);
        }


        /// <summary>
        /// check if month is feb and if the 1st is on sunday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool is4WeekMonth(object sender, EventArgs e)
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

        /// <summary>
        /// returns if current month has 6 weeks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected bool is6WeekMonth(object sender, EventArgs e)
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

        /// <summary>
        /// Sets Visual table to show 4 week month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        /// 
        protected void set4WeekMonth(object sender, EventArgs e)
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
        /// <summary>
        /// Sets visual table to show 5 week month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void set5WeekMonth(object sender, EventArgs e)
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
        /// <summary>
        /// Calculates totals for table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calculateTotals(object sender, EventArgs e)
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


    }
}