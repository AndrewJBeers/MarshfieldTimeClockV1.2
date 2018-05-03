using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarshfieldTimeClock_V1._1
{
    public partial class TimeClockMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTimeClock_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimeClock.aspx");
        }

        protected void btnHoursWorked_Click(object sender, EventArgs e)
        {
            Response.Redirect("HoursWorked.aspx");
        }
    }
}