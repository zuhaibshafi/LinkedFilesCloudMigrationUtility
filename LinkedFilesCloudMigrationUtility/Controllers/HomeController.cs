using LinkedFilesCloudMigrationUtility.Models;
using LinkedFilesCloudMigrationUtility.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedFilesCloudMigrationUtility.Controllers
{
    public class HomeController : Controller
    {
        public string constr = "";

        public ActionResult Index()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult ConnectSQL(LogIn login)
        {
            try
            {
                 constr = "Data Source=" + login.ServerName + "; User ID=" + login.Username + "; Password=" + login.Password + "";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Select db.[name] as dbname from [master].[sys].[databases] db";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                con.Close();
                List<string> databaseList = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    databaseList.Add(dt.Rows[i]["dbname"].ToString());
                }
                ViewBag.DBlist = databaseList;   
                con.Close();
            }

            catch (Exception es)
            {
                ModelState.AddModelError("Error", "Error! Please Check Your Credentials.");
            }
            return View("Index");
        }

        public void InsertData()
        {
                SqlConnection con = null;
                string newconstr = constr + "; Initial Catalog=GalaxySample";
                con = new SqlConnection(newconstr);
                SqlCommand cmd = new SqlCommand("Insert into  LinkedFile (Title) Values ('abc') ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
          
        }
        public void UpdateData()
            {
                    string newconstr = constr + "; Initial Catalog=GalaxySample";
                    SqlConnection con = null;  
                    con = new SqlConnection(newconstr);
                    SqlCommand cmd = new SqlCommand("Update LinkedFile set title = 'NULL' where LinkedFile_ID = '695A104F-8DBF-42DE-B06B-4FE7E8FE7D6E'", con);                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
               
            }

        public static OAuthToken GetOneDriveConsumerAppInfo()
        {
            string consumerKey = SettingManager.GetThirdPartyAppKeysSetting("onedrive", "consumerkey");
            string consumerSecret = SettingManager.GetThirdPartyAppKeysSetting("onedrive", "consumersecret");
            return new OAuthToken(consumerKey, consumerSecret);

        }

    }
}