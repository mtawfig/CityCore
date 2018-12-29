﻿using CityCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Modules.Projects
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string a = PROJECT_LEVEL.DESIGNING;
            if (!IsPostBack)
            {
                FillListView();
            }
        }

        private void FillListView(string condition = "")
        {
            try
            {
                string qry = " SELECT * FROM PROJECT WHERE ISNULL(IS_DELETED,0)=0 ";
                lvMain.DataSource = PublicFunctions.ExecuteSqlQuery(qry);
                lvMain.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}