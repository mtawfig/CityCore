using CityCore.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Pages
{
    public partial class CityCore : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            bool isAuthenticated =
                                    (System.Web.HttpContext.Current.User != null) &&
                                    System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                //PublicVariables.drCompany = PublicFunctions.GetCompanyInfo();
                PublicVariables.drUser = PublicFunctions.GetCurrentUser();

                //if (PublicVariables.drCompany == null || PublicVariables.drUser == null)
                if (PublicVariables.drUser == null)
                {
                    Logout(this, e);
                }

                //lblCompanyName.Text = PublicVariables.drCompany["Name"].ToString();
                lblUsername.Text = PublicVariables.drUser["FULLNAME"].ToString();
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            PublicVariables.drUser = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search(object sender, EventArgs e)
        {
            try
            {
                string qry = " SELECT * FROM PROJECT WHERE ISNULL(IS_DELETED,0)=0 AND ID= " + txtProjectNo.Text;
                DataTable dt = PublicFunctions.ExecuteSqlQuery(qry);
                if (dt == null)
                {
                    Clear(lbClear, e);
                    return;
                }
                if (dt.Rows.Count == 0)
                {
                    Clear(lbClear, e);
                    return;
                }

                txtAdmID.Text = dt.Rows[0]["ADM_ID"].ToString();
                txtProjectName.Text = dt.Rows[0]["NAME"].ToString();
                txtFileName.Text = dt.Rows[0]["FILE_NAME"].ToString();
                txtLandLord.Text = dt.Rows[0]["LANDLORD"].ToString();
                txtOwnerName.Text = dt.Rows[0]["TENANT_NAME"].ToString();
                txtGeneralStatus.Text = dt.Rows[0]["STATUS"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Clear(object sender, EventArgs e)
        {
            PublicFunctions.ClearPanelControls(pnlFilters);
        }
    }
}