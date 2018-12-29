using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Helpers
{
    public class PublicFunctions
    {
        #region Strings

        public static string HashString(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        public static Boolean IsDate(object val, out DateTime temp)
        {
            if (val == null)
            {
                temp = DateTime.MinValue;
                return false;
            }

            if (!DateTime.TryParse(val.ToString(), out temp))
            {
                temp = DateTime.MinValue;
                return false;
            }

            return true;
        }

        public static string DateToStringIfNotNull(object val, string format = "")
        {
            DateTime outputDate;
            if (!IsDate(val, out outputDate))
            {
                return "";
            }
            else
            {
                if (format == "")
                {
                    format = "yyyy-MM-dd";
                }
                return outputDate.ToString(format);
            }
        }

        #endregion

        #region Database

        /// <summary>
        /// Execute SQL query and return data table
        /// </summary>
        /// <param name="qry">Query string</param>
        /// <returns></returns>
        public static DataTable ExecuteSqlQuery(string qry)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(PublicVariables.conStr))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(qry, con))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Execute SQL query and return data table within provided connection and transaction
        /// </summary>
        /// <param name="qry">Query string</param>
        /// <param name="trans">Transaction</param>
        /// <param name="con">Connection</param>
        /// <returns></returns>
        public static DataTable ExecuteSqlQuery(string qry, SqlTransaction trans, SqlConnection con)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(qry, con))
                {
                    da.SelectCommand.Transaction = trans;
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Execute SQL query and return value of first column of the result's first row
        /// </summary>
        /// <param name="qry">Query string</param>
        /// <returns></returns>
        public static object ExecuteSqlScalar(string qry)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(PublicVariables.conStr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Execute SQL query and return value of first column of the result's first row
        /// </summary>
        /// <param name="qry">Query string</param>
        /// <param name="trans">Transaction</param>
        /// <param name="con">Connection</param>
        /// <returns></returns>
        public static object ExecuteSqlScalar(string qry, SqlTransaction trans, SqlConnection con)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(qry, con, trans))
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Execute SQL command and return true/false
        /// </summary>
        /// <param name="cmdStr">Command string</param>
        /// <returns></returns>
        public static bool ExecuteSqlCommand(string cmdStr)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(PublicVariables.conStr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdStr, con))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Execute SQL command and return true/false
        /// </summary>
        /// <param name="cmdStr">Command string</param>
        /// <param name="trans">Transaction</param>
        /// <param name="con">Connection</param>
        /// <returns></returns>
        public static bool ExecuteSqlCommand(string cmdStr, SqlTransaction trans, SqlConnection con)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(cmdStr, con, trans))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Messages and Logging

        public static void ShowSuccessMessage(ref Label lbl, string msg)
        {
            lbl.CssClass = "alert alert-success panel-footer";
            lbl.Text = msg;
            lbl.Visible = true;
        }

        public static void ShowWarningMessage(ref Label lbl, string msg)
        {
            lbl.CssClass = "alert alert-warning panel-footer";
            lbl.Text = msg;
            lbl.Visible = true;
        }

        public static void ShowErrorMessage(ref Label lbl, string msg)
        {
            lbl.CssClass = "alert alert-danger panel-footer";
            lbl.Text = msg;
            lbl.Visible = true;
        }

        public static void WriteExceptionLog(Page pg, string logStr)
        {
            string logFile = pg.Server.MapPath("~/Logs/Exceptions/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            using (StreamWriter st = new StreamWriter(logFile, true))
            {

                st.WriteLine("Date and time: " + DateTime.Now.ToString());
                st.WriteLine(logStr);
                st.WriteLine("********************************************************* \n\n");
            }
        }

        public static void WriteErrorLog(Page pg, string logStr)
        {
            string logFile = pg.Server.MapPath("~/Logs/Business/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            using (StreamWriter st = new StreamWriter(logFile, true))
            {

                st.WriteLine("Date and time: " + DateTime.Now.ToString());
                st.WriteLine(logStr);
                st.WriteLine("********************************************************* \n\n");
            }
        }

        public static void WriteLog4NetError(string errorMsg)
        {
            ILog logger = log4net.LogManager.GetLogger("ErrorLog");
            logger.Error(errorMsg);
        }

        #endregion

        #region Form Controls

        public static void ClearPanelControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox t)
                {
                    t.Text = string.Empty;
                }
                else if (ctrl is HiddenField h)
                {
                    h.Value = string.Empty;
                }
                else if (ctrl is DropDownList d)
                {
                    d.SelectedIndex = 0;
                }
                else if (ctrl is CheckBox c)
                {
                    c.Checked = false;
                }
                else if (ctrl is RadioButtonList r)
                {
                    r.SelectedIndex = 0;
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearPanelControls(ctrl);
                    }
                }
            }
        }

        #endregion

        #region Number Functions

        public static Boolean IsInterger(object val)
        {
            if (val == null)
            {
                return false;
            }

            int result;
            return int.TryParse(val.ToString(), out result);
        }

        public static Boolean IsNumeric(object val)
        {
            decimal result;
            return decimal.TryParse(val.ToString(), out result);
        }

        public static int? StringToInt(string val)
        {
            if (IsInterger(val))
            {
                return int.Parse(val);
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Get current logged in user detail from the database
        /// </summary>
        /// <returns></returns>
        public static DataRow GetCurrentUser()
        {
            try
            {
                var id = HttpContext.Current.User.Identity.Name;
                var dt = ExecuteSqlQuery(string.Format("SELECT *, (SELECT NAME FROM COMPANY WHERE ID=EMPLOYEE.COMPANY_ID) AS ClientName " +
                    " FROM EMPLOYEE WHERE ID={0} AND ISNULL(Is_Deleted,0)=0 ", id));
                if (dt == null)
                {
                    return null;
                }
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                return dt.Rows[0];
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        /// <summary>
        /// Get current company details from the database
        /// </summary>
        /// <returns></returns>
        public static DataRow GetCompanyInfo()
        {
            try
            {
                var id = HttpContext.Current.User.Identity.Name;
                var dt = ExecuteSqlQuery("SELECT * FROM CompanyInfo WHERE ISNULL(IsDeleted,0)=0 ");
                if (dt == null)
                {
                    return null;
                }
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                return dt.Rows[0];
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        /// <summary>
        /// Generate JSON from DataTable
        /// </summary>
        /// <param name="dt">Data table</param>
        /// <returns></returns>
        public static string ConvertDataTableToJson(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc]);
                }
                list.Add(result);
            }
            return new JavaScriptSerializer().Serialize(list);
        }

        /// <summary>            
        /// Generate Serial Code
        /// Example usage: PublicFunctions.GenerateCode("Payments", "Code", "D", 13);
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="column">Column name</param>
        /// <param name="fc">First characters</param>
        /// <param name="length">Length of the code</param>
        /// <returns></returns>
        public static string GenerateCode(string table, string column, string fc, int length)
        {
            string code = "";
            string prefix = fc + "-" + DateTime.Now.ToString("yyyyMM") + "-";
            string serial = "";

            string qstr = string.Format("SELECT CONVERT(INT, SUBSTRING({0}, {1}, {2})) " +
                " FROM {3} WHERE {4} LIKE '{5}%' AND LEN({6})={7} ",
                column, prefix.Length + 1, length - fc.Length, table, column, prefix, column, length);

            object lastCode = PublicFunctions.ExecuteSqlScalar(qstr);

            if (!PublicFunctions.IsInterger(lastCode))
            {
                lastCode = 0;
            }

            serial = (int.Parse(lastCode.ToString()) + 1).ToString().PadLeft(length - fc.Length, '0');
            code = prefix + serial;

            return code;
        }

        /// <summary>
        /// Fill dropdownlist from database
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="qry"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        public static void FillDropDownList(ref DropDownList ddl,string qry, string valueField, string textField)
        {
            try
            {
                ddl.DataSource = PublicFunctions.ExecuteSqlQuery(qry);
                ddl.DataTextField = textField;
                ddl.DataValueField = valueField;
                ddl.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}