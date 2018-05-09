using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWBArchiving.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetCreateViewWithNewDB()
        {
            return PartialView("~/Views/Admin/PV_CreateNewViewWithDatabase.cshtml");

        }

        public JsonResult GetDBs(string db, string uname,string pass)
        {
            string sqlConnection;
            if (string.IsNullOrEmpty(db))
                db = ".";

            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pass))
            {
                //sqlConnection = new SqlConnection(string.Format("data source={0};Initial Catalog=ArchivingDB;Integrated Security=SSPI;"));
                sqlConnection = string.Format("data source={0};Integrated Security=SSPI;", db);
            }
            else
            {
                //User ID=xxxxxxx;Password=xxxxxxx;
                sqlConnection = string.Format("data source={0};User ID={1};Password={2}", db, uname,pass);

            }
            List<string> dbs = new List<string>();
            using (var con = new SqlConnection(sqlConnection))
            {
                con.Open();
                DataTable databases = con.GetSchema("Databases");
                foreach (DataRow database in databases.Rows)
                {
                    String databaseName = database.Field<String>("database_name");
                    dbs.Add(databaseName);
                }
            }
            return Json(dbs, JsonRequestBehavior.AllowGet);

        }
    }
}