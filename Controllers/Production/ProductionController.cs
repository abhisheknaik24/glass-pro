using MyApp.Filters;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers.Production
{
    [UserAuthenticationFilter]
    public class ProductionController : Controller
    {
        public ActionResult Cutting()
        {
            List<ProductionModel> list = DBModel.Productions("Cutting");
            ViewBag.List = list;
            return View();
        }

        public JsonResult LoadCuttingProduction(string WorkOrderNo)
        {
            List<ProductionModel> list = DBModel.ProducedQty("Cutting", WorkOrderNo);
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveCutting(string WorkOrderNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("ActualQty");
                data.Columns.Add("BalancedQty");
                data.Columns.Add("ProducedQty");
                data.TableName = "PT_Production";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["ActualQty"] = production.ActualQty;
                    row["BalancedQty"] = production.BalancedQty;
                    row["ProducedQty"] = production.ProducedQty;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveProduction("USP_SaveCutting", WorkOrderNo, UserId, data);
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

        public ActionResult Polishing()
        {
            List<ProductionModel> list = DBModel.Productions("Polishing");
            ViewBag.List = list;
            return View();
        }

        public JsonResult LoadPolishingProduction(string WorkOrderNo)
        {
            List<ProductionModel> list = DBModel.ProducedQty("Polishing", WorkOrderNo);
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SavePolishing(string WorkOrderNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("ActualQty");
                data.Columns.Add("BalancedQty");
                data.Columns.Add("ProducedQty");
                data.TableName = "PT_Production";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["ActualQty"] = production.ActualQty;
                    row["BalancedQty"] = production.BalancedQty;
                    row["ProducedQty"] = production.ProducedQty;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveProduction("USP_SavePolishing", WorkOrderNo, UserId, data);
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

        public ActionResult Fabrication()
        {
            List<ProductionModel> list = DBModel.Productions("Fabrication");
            ViewBag.List = list;
            return View();
        }

        public JsonResult LoadFabricationProduction(string WorkOrderNo)
        {
            List<ProductionModel> list = DBModel.ProducedQty("Fabrication", WorkOrderNo);
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveFabrication(string WorkOrderNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("ActualQty");
                data.Columns.Add("BalancedQty");
                data.Columns.Add("ProducedQty");
                data.TableName = "PT_Production";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["ActualQty"] = production.ActualQty;
                    row["BalancedQty"] = production.BalancedQty;
                    row["ProducedQty"] = production.ProducedQty;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveProduction("USP_SaveFabrication", WorkOrderNo, UserId, data);
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

        public ActionResult Toughening()
        {
            List<ProductionModel> list = DBModel.Productions("Toughening");
            ViewBag.List = list;
            return View();
        }

        public JsonResult LoadTougheningProduction(string WorkOrderNo)
        {
            List<ProductionModel> list = DBModel.ProducedQty("Toughening", WorkOrderNo);
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveToughening(string WorkOrderNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("ActualQty");
                data.Columns.Add("BalancedQty");
                data.Columns.Add("ProducedQty");
                data.TableName = "PT_Production";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["ActualQty"] = production.ActualQty;
                    row["BalancedQty"] = production.BalancedQty;
                    row["ProducedQty"] = production.ProducedQty;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveProduction("USP_SaveToughening", WorkOrderNo, UserId, data);
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

        public ActionResult DGU()
        {
            List<ProductionModel> list = DBModel.Productions("DGU");
            ViewBag.List = list;
            return View();
        }

        public JsonResult LoadDGUProduction(string WorkOrderNo)
        {
            List<ProductionModel> list = DBModel.ProducedQty("DGU", WorkOrderNo);
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveDGU(string WorkOrderNo, List<ProductionModel> Production)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            if (Production != null)
            {
                DataTable data = new DataTable();
                data.Columns.Add("ItemId");
                data.Columns.Add("ItemName");
                data.Columns.Add("ActualQty");
                data.Columns.Add("BalancedQty");
                data.Columns.Add("ProducedQty");
                data.TableName = "PT_Production";
                foreach (ProductionModel production in Production)
                {
                    DataRow row = data.NewRow();
                    row["ItemId"] = production.ItemId;
                    row["ItemName"] = production.ItemName;
                    row["ActualQty"] = production.ActualQty;
                    row["BalancedQty"] = production.BalancedQty;
                    row["ProducedQty"] = production.ProducedQty;
                    data.Rows.Add(row);
                }
                dataTable = DBModel.SaveProduction("USP_SaveDGU", WorkOrderNo, UserId, data);
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

        public ActionResult Dispatch()
        {
            return View();
        }

        public JsonResult LoadDispatch()
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_LoadDispatch");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult UpdateDispatch(int WorkOrderDId)
        {
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_UpdateDispatch '" + WorkOrderDId + "'");
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    responseModel.Status = Convert.ToInt32(row["Status"]);
                    responseModel.Message = Convert.ToString(row["Message"]);
                }
            }
            var jsonResult = Json(responseModel, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}