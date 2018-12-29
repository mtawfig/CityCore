using CityCore.Helpers;
using CityCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CityCore.Modules.Projects
{
    public partial class AddEdit : System.Web.UI.Page
    {
        private CityCoreDBEntities db = new CityCoreDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //PublicFunctions.CheckPermission(page_name);

                PublicFunctions.FillDropDownList(ref ddlProjectManager, " SELECT ID, FULLNAME FROM EMPLOYEE WHERE ISNULL(IS_DELETED, 0)=0 ", "ID", "FULLNAME");
                PublicFunctions.FillDropDownList(ref ddlManagingDirector, " SELECT ID, FULLNAME FROM EMPLOYEE WHERE ISNULL(IS_DELETED, 0)=0 ", "ID", "FULLNAME");

                lbSaveTop.CommandName = "add";
                if (Page.RouteData.Values["id"] != null)
                {
                    var id = PublicFunctions.StringToInt(Page.RouteData.Values["id"].ToString());
                    if (FillForm(id))
                    {
                        lbSaveTop.CommandName = "edit";
                    }
                    else
                    {
                        Response.Redirect("/Projects");
                    }
                }
            }
            catch (Exception ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                throw;
            }
        }

        private bool FillForm(int? id)
        {
            try
            {
                var obj = db.PROJECTs.SingleOrDefault(p => p.ID == id);
                if (obj == null)
                {
                    Response.Write("<script>alert('Error: Cannot retrieve data!');</script>");
                    return false;
                }
                else
                {
                    hfID.Value = obj.ID.ToString();
                    txtName.Text = obj.NAME;
                    txtAdmID.Text = obj.ADM_ID;
                    txtFileName.Text = obj.FILE_NAME;
                    txtLandlord.Text = obj.LANDLORD;
                    txtTenantName.Text = obj.TENANT_NAME;
                    txtPropertyManager.Text = obj.PROPERTY_MNGR;
                    txtArea.Text = obj.AREA;
                    txtSector.Text = obj.SECTOR;
                    txtPlot.Text = obj.PLOT;
                    txtUnitNo.Text = obj.UNIT_NO;
                    ddlProjectManager.SelectedValue = obj.PROJECT_MGR.ToString();
                    ddlManagingDirector.SelectedValue = obj.MANAGING_DIRECTOR.ToString();
                    txtStatus.Text = obj.STATUS;
                    txtNotes.Text = obj.NOTES;
                    return true;
                }
            }
            catch (Exception ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                return false;
            }
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            try
            {
                PublicVariables.drUser = PublicFunctions.GetCurrentUser();

                if (lbSaveTop.CommandName.ToLower() == "add")
                {
                    PROJECT obj = new PROJECT()
                    {
                        NAME = txtName.Text,
                        ADM_ID = txtAdmID.Text,
                        FILE_NAME = txtFileName.Text,
                        LANDLORD = txtLandlord.Text,
                        TENANT_NAME = txtTenantName.Text,
                        PROPERTY_MNGR = txtPropertyManager.Text,
                        AREA = txtArea.Text,
                        SECTOR = txtSector.Text,
                        PLOT = txtPlot.Text,
                        UNIT_NO = txtUnitNo.Text,
                        PROJECT_MGR = PublicFunctions.StringToInt(ddlProjectManager.SelectedValue),
                        MANAGING_DIRECTOR = PublicFunctions.StringToInt(ddlManagingDirector.SelectedValue),
                        STATUS = PROJECT_STATUS.NEW,
                        NOTES = txtNotes.Text,
                        COMPANY_ID = PublicFunctions.StringToInt(PublicVariables.drUser["COMPANY_ID"].ToString()),
                        CREATE_BY = PublicFunctions.StringToInt(PublicVariables.drUser["ID"].ToString()),
                        CREATE_DATE = DateTime.Now
                    };
                    db.PROJECTs.Add(obj);
                }
                else
                {
                    var id = PublicFunctions.StringToInt(hfID.Value);

                    if (db.PROJECTs.Where(p => p.ID == id).ToList().Count > 0)
                    {
                        PROJECT obj = db.PROJECTs.SingleOrDefault(p => p.ID == id);
                        {
                            obj.NAME = txtName.Text;
                            obj.ADM_ID = txtAdmID.Text;
                            obj.FILE_NAME = txtFileName.Text;
                            obj.LANDLORD = txtLandlord.Text;
                            obj.TENANT_NAME = txtTenantName.Text;
                            obj.PROPERTY_MNGR = txtPropertyManager.Text;
                            obj.AREA = txtArea.Text;
                            obj.SECTOR = txtSector.Text;
                            obj.PLOT = txtPlot.Text;
                            obj.UNIT_NO = txtUnitNo.Text;
                            obj.PROJECT_MGR = PublicFunctions.StringToInt(ddlProjectManager.SelectedValue);
                            obj.MANAGING_DIRECTOR = PublicFunctions.StringToInt(ddlManagingDirector.SelectedValue);
                            obj.STATUS = PROJECT_STATUS.NEW;
                            obj.NOTES = txtNotes.Text;
                            obj.COMPANY_ID = PublicFunctions.StringToInt(PublicVariables.drUser["COMPANY_ID"].ToString());
                            obj.UPDATE_BY = PublicFunctions.StringToInt(PublicVariables.drUser["ID"].ToString());
                            obj.UPDATE_DATE = DateTime.Now;
                        };
                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        Response.Write("<script>alert('Error: Failed to Save!');</script>");
                        return;
                    }
                }

                db.SaveChanges();
                Response.Write("<script>alert('Saved successfully!');</script>");
                Response.Redirect("List.aspx?action=save", true);
            }
            catch (DbEntityValidationException ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                Response.Write("<script>alert('Error: Failed to Save!');</script>");
                throw;
            }
            catch (EntityException ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                Response.Write("<script>alert('Error: Failed to Save!');</script>");
                throw;
            }
            catch (DataException ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                Response.Write("<script>alert('Error: Failed to Save!');</script>");
                throw;
            }
            catch (Exception ex)
            {
                PublicFunctions.WriteLog4NetError(ex.ToString());
                Response.Write("<script>alert('Error: Failed to Save!');</script>");
                throw;
            }
        }

        protected void CancelClick(object sender, EventArgs e)
        {
            //PublicFunctions.ClearPanelControls(pnlForm);
            Response.Redirect("/Project");
        }
    }


}