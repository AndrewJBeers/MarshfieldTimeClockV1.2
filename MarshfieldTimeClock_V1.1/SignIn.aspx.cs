using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarshfieldTimeClock_V1._1
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("###############PageLoad");
            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("###############!IPostBack");
                if (txtBxUserName.Text == "")
                {
                    txtBxUserName.Text = "paul.rottmund";
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            if (txtBxUserName.Text != "")
            {
                System.Diagnostics.Debug.WriteLine("###############BtnSignIn");
                Employee myEmployee = new Employee(txtBxUserName.Text);

                Session["Employee"] = myEmployee;
                System.Diagnostics.Debug.WriteLine("############SignIn" + Session["Employee"]);
                Response.Redirect("TimeClock.aspx");
            }


            /// if username and password are not empty
            try
            {
                /// LADP authentication
                /// ~~ if authorized 
                ///     log in and go to time clock page
                /// ~~ else (not authorized)
                ///     error msg wrong username or password


            }
            catch
            {

            }
        }
    }
}