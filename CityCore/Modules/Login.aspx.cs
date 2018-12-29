using CityCore.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Modules
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginClick(object sender, EventArgs e)
        {
            try
            {
                //Hide message
                lblMsg.Visible = false;

                //Validate data and authenticate user. 
                //If something is wrong show message to user, else redirect to home page
                if (ValidateUser(txtUsername.Text.Trim(), txtPassword.Text))
                {
                    //PublicVariables.drCompany = PublicFunctions.GetCompanyInfo();
                    FormsAuthentication.RedirectFromLoginPage(hfUserID.Value, false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateUser(string username, string password)
        {
            try
            {
                //First, validate data (ex: for empty username or password, for sql injection, ...)

                if (username == string.Empty || password == string.Empty)
                {
                    //Show alert message for required user or password
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "Username and Password required!");
                    //and return false
                    return false;
                }

                //Array of invalid characters for the username and password
                char[] invalidChars = { '@', '/', '\\', '&', '#', '*', '$', '!', '%', '^', '(', ')',
                                        '[', ']', '{', '}', '=', '+', '|', '"', '\'', '.', ',', '?' };

                if (username.IndexOfAny(invalidChars) >= 0 || password.IndexOfAny(invalidChars) >= 0)
                {
                    //Show alert message for invalid characters
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "Username or Password incorrect!");
                    //and return false
                    return false;
                }

                if (PublicVariables.drClient == null)
                {
                    //Show alert message for invalid characters
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "Company is not selected!");
                    //and return false
                    return false;
                }

                //Second, check the user data from the database logins table
                //password = PublicFunctions.HashString(password);

                DataTable dt = PublicFunctions.ExecuteSqlQuery(
                    string.Format(
                        "SELECT *, (SELECT NAME FROM COMPANY WHERE ID=EMPLOYEE.COMPANY_ID) AS ClientName " +
                        " FROM EMPLOYEE WHERE USERNAME='{0}' AND PASSWORD='{1}' AND COMPANY_ID={2} AND ISNULL(IS_DELETED,0)=0 ",
                        username, password, PublicVariables.drClient["ID"].ToString()));

                if (dt == null)
                {
                    //Show alert message
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "User info incorrect!");
                    //and return false
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    //Show alert message
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "User info incorrect!");
                    //and return false
                    return false;
                }

                //Set the public variable user data row to the logged in user
                PublicVariables.drUser = dt.Rows[0];
                hfUserID.Value = dt.Rows[0]["ID"].ToString();
                //and return true
                return true;
            }
            catch (Exception ex)
            {
                //Show error message
                PublicFunctions.ShowErrorMessage(ref lblMsg, ex.ToString());
                //and return false
                return false;
            }
        }

        protected void CompanyChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Visible = false;

                DataTable dt = PublicFunctions.ExecuteSqlQuery(
                            string.Format(
                                " SELECT * FROM COMPANY WHERE CODE='{0}' AND ISNULL(IS_ACTIVE,0) <> 0 " +
                                " AND ISNULL(IS_DELETED,0)=0 ", txtCompanyCode.Text.Trim()));

                if (dt == null)
                {
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "Client ID incorrect!");
                    PublicFunctions.ClearPanelControls(pnlLoginInfo);
                    pnlLoginInfo.Enabled = false;
                    return;
                }
                if (dt.Rows.Count == 0)
                {
                    PublicFunctions.ShowWarningMessage(ref lblMsg, "Client ID incorrect!");
                    PublicFunctions.ClearPanelControls(pnlLoginInfo);
                    pnlLoginInfo.Enabled = false;
                    return;
                }

                PublicVariables.drClient = dt.Rows[0];
                pnlLoginInfo.Enabled = true;
            }
            catch (Exception ex)
            {
                PublicFunctions.ShowErrorMessage(ref lblMsg, ex.ToString());
                PublicFunctions.ClearPanelControls(pnlLoginInfo);
                pnlLoginInfo.Enabled = false;
            }
        }
    }
}