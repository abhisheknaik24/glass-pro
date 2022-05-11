using MyApp.Filters;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers.WorkOrder
{
    [UserAuthenticationFilter]
    public class WorkOrderController : Controller
    {
        public ActionResult WorkOrder()
        {
            List<ItemModel> list = DBModel.InStockItems();
            ViewBag.Items = new SelectList(list, "ItemId", "ItemName");
            return View();
        }

        public JsonResult LoadWorkOrder()
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_LoadWorkOrder");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult InStockQtyWorkOrder(int ItemId)
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_InStockQtyWorkOrder '" + ItemId + "'");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveWorkOrder(string WorkOrderDate, string CustomerName, string Address, int PhoneNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("Qty");
                data.Columns.Add("Cutting");
                data.Columns.Add("Polishing");
                data.Columns.Add("Fabrication");
                data.Columns.Add("Toughening");
                data.Columns.Add("DGU");
                data.TableName = "PT_WorkOrderD";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["Qty"] = production.Qty;
                    row["Cutting"] = production.Cutting;
                    row["Polishing"] = production.Polishing;
                    row["Fabrication"] = production.Fabrication;
                    row["Toughening"] = production.Toughening;
                    row["DGU"] = production.DGU;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveWorkOrder(WorkOrderDate, CustomerName, Address, PhoneNo, UserId, data);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        responseModel.Status = Convert.ToInt32(row["Status"]);
                        responseModel.Message = Convert.ToString(row["Message"]);
                    }
                }
            }
            var jsonResult = Json(responseModel, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}