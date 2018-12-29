using CityCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Modules.Projects
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                if (!IsPostBack)
                {
                    FillListView();
                }

                //Test log4net
                //throw new Exception("InvalidOperationException", new InvalidOperationException());
            }
            catch (Exception ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
            }
        }

        private void FillListView(string condition = "")
        {
            try
            {
                string qry = " SELECT * FROM PROJECT WHERE ISNULL(IS_DELETED,0)=0 ";
                if (Request.QueryString.Get("Status") != null && Request.QueryString.Get("Status") != string.Empty)
                {
                    var Status = Request.QueryString.Get("Status");
                    qry += " AND Status='" + Status + "' ";
                }
                lvMain.DataSource = PublicFunctions.ExecuteSqlQuery(qry);
                lvMain.DataBind();
            }
            catch (Exception ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                throw;
            }
        }
    }
}