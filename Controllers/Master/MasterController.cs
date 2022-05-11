using MyApp.Filters;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers.Master
{
    [UserAuthenticationFilter]
    public class MasterController : Controller
    {
        public ActionResult Item()
        {
            return View();
        }

        public JsonResult LoadItem()
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_LoadItem");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveItem(int ItemId, string ItemName, decimal Rate, string Unit, int Height, int Width)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            ResponseModel responseModel = new ResponseModel();
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_SaveItem '" + ItemId + "','" + ItemName  + "','" + Rate + "','" + Unit + "','" + Height + "','" + Width + "','" + UserId + "'");
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

        public JsonResult UpdateItem(int ItemId)
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_UpdateItem '" + ItemId + "'");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public JsonResult LoadInventory()
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_LoadInventory");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Settings()
        {
            return View();
        }

        public JsonResult LoadSettings()
        {
            DataTable dataTable = new DataTable();
            dataTable = DBModel.GetDataTable("USP_LoadSettings");
            string json = JsonConvert.SerializeObject(dataTable);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}