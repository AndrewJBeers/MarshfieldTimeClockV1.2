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
            if (!IsPostBack)
            {
                try
                {
                    if (txtBxUserName.Text == "")
                    {
                        txtBxUserName.Text = "paul.rottmund";
                        //rogina.totten
                    }
                }
                catch(Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine("######### SIGNIN Page_Load():  " + exc.Message);
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBxUserName.Text != "")
                {
                    Employee myEmployee = new Employee(txtBxUserName.Text);
                    Session["Employee"] = myEmployee;
                    Response.Redirect("TimeClock.aspx",false);
                }
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### SIGNIN btnSignIn_Click():  " + exc.Message);

            }

        }
    }
}