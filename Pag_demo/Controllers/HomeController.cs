using Pag_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace Pagination_demo.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        string filename;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ExcelData"].ConnectionString);
        OleDbConnection Econ = null;

        public string UserName { get; private set; }
        public object Password { get; private set; }
        public object RememberMe { get; private set; }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }
        public ActionResult Index(string SortOrder, string SortBy, int? Page_No,int ? show)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            List<FileUploadLog> files = new List<FileUploadLog>();

            using (SqlCommand cmd = new SqlCommand("Select * from FileUploadLog", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        adp.Fill(dt);
                        DataView view = new DataView(dt);

                        switch (SortBy)
                        {
                            case "ID":
                                {
                                    switch (SortOrder)
                                    {
                                        case "Desc":
                                            {
                                                view.Sort = "ID DESC";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }
                                        case "Asc":
                                            {
                                                view.Sort = "ID ASC";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }

                                        default:
                                            view.Sort = "ID DESC";
                                            foreach (DataRowView item in view)
                                            {
                                                FileUploadLog ful = new FileUploadLog();
                                                ful.ID = Convert.ToInt32(item["ID"]);
                                                ful.FileName = item["File Name"].ToString();
                                                ful.UploadedOn = item["Uploaded On"].ToString();
                                                ful.Status = item["Status"].ToString();
                                                files.Add(ful);
                                            }

                                            break;
                                    }
                                    break;
                                }
                            case "File Name":
                                {
                                    switch (SortOrder)
                                    {
                                        case "Desc":
                                            {
                                                view.Sort = "File Name DESC";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }
                                        case "Asc":
                                            {
                                                view.Sort = "File Name ASC";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }


                                        default:
                                            view.Sort = "File Name DESC";
                                            foreach (DataRowView item in view)
                                            {
                                                FileUploadLog ful = new FileUploadLog();
                                                ful.ID = Convert.ToInt32(item["ID"]);
                                                ful.FileName = item["File Name"].ToString();
                                                ful.UploadedOn = item["Uploaded On"].ToString();
                                                ful.Status = item["Status"].ToString();
                                                files.Add(ful);
                                            }

                                            break;
                                    }
                                    break;
                                }
                            case "Uploaded On":
                                {
                                    switch (SortOrder)
                                    {
                                        case "Desc":
                                            {
                                                view.Sort = "Uploaded On DESC";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }
                                        case "Asc":
                                            {
                                                view.Sort = "Uploaded On ASc";
                                                foreach (DataRowView item in view)
                                                {
                                                    FileUploadLog ful = new FileUploadLog();
                                                    ful.ID = Convert.ToInt32(item["ID"]);
                                                    ful.FileName = item["File Name"].ToString();
                                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                                    ful.Status = item["Status"].ToString();
                                                    files.Add(ful);
                                                }
                                                break;
                                            }

                                        default:
                                            view.Sort = "Uploaded On DESC";
                                            foreach (DataRowView item in view)
                                            {
                                                FileUploadLog ful = new FileUploadLog();
                                                ful.ID = Convert.ToInt32(item["ID"]);
                                                ful.FileName = item["File Name"].ToString();
                                                ful.UploadedOn = item["Uploaded On"].ToString();
                                                ful.Status = item["Status"].ToString();
                                                files.Add(ful);
                                            }

                                            break;
                                    }
                                    break;
                                }
                            default:
                                view.Sort = "ID DESC";
                                foreach (DataRowView item in view)
                                {
                                    FileUploadLog ful = new FileUploadLog();
                                    ful.ID = Convert.ToInt32(item["ID"]);
                                    ful.FileName = item["File Name"].ToString();
                                    ful.UploadedOn = item["Uploaded On"].ToString();
                                    ful.Status = item["Status"].ToString();
                                    files.Add(ful);
                                }
                                break;
                        }
                    }
                }
            }
            int Size_Of_Page = (int)(show ?? 5);
            int No_Of_Page = (Page_No ?? 1);
            return View(files.ToPagedList(No_Of_Page , Size_Of_Page));
        }



        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, int? Page_No,int? show )
        {
            HttpPostedFileBase myfile = Request.Files[0];
            filename = Path.GetFileName(file.FileName);

            //filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelFolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelFolder"), filename));
            InsertExcelData(filepath, filename);
            List<FileUploadLog> files = new List<FileUploadLog>();

            using (SqlCommand cmd1 = new SqlCommand("DisplayDetail", con))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    FileUploadLog fu = new FileUploadLog();
                    fu.ID = Convert.ToInt32(reader["ID"]);
                    fu.FileName = reader["File Name"].ToString();
                    fu.UploadedOn = Convert.ToString(reader["Uploaded On"]);
                    fu.Status = reader["Status"].ToString();
                    files.Add(fu);
                }
                reader.Close();
            }
            //return View(files.ToList());
            int Size_Of_Page = (int)(show ?? 5);
            int No_Of_Page = (Page_No ?? 1);
            return View(files.ToPagedList(No_Of_Page, Size_Of_Page));
           /* int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);
            return View(files.ToPagedList(No_Of_Page, Size_Of_Page));*/

        }

        private void InsertExcelData(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelFolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];


            SqlBulkCopy objbulk = new SqlBulkCopy(con);

            objbulk.DestinationTableName = "Excel";

            objbulk.ColumnMappings.Add("Date Collected", "Date Collected");
            objbulk.ColumnMappings.Add("Financial Year", "Financial Year");
            objbulk.ColumnMappings.Add("Calendar Year", "Calendar Year");
            objbulk.ColumnMappings.Add("Quarter", "Quarter");
            objbulk.ColumnMappings.Add("Calendar Week", "Calendar Week");
            objbulk.ColumnMappings.Add("Calendar Month", "Calendar Month");
            objbulk.ColumnMappings.Add("Financial Month", "Financial Month");
            objbulk.ColumnMappings.Add("Country", "Country");
            objbulk.ColumnMappings.Add("Store Banner", "Store Banner");
            objbulk.ColumnMappings.Add("Store Type", "Store Type");
            objbulk.ColumnMappings.Add("Seller Name", "Seller Name");
            objbulk.ColumnMappings.Add("Product Division", "Product Division");
            objbulk.ColumnMappings.Add("RPC", "RPC");
            objbulk.ColumnMappings.Add("MPC", "MPC");
            objbulk.ColumnMappings.Add("Product Name", "Product Name");
            objbulk.ColumnMappings.Add("Product Rating", "Product Rating");
            objbulk.ColumnMappings.Add("Listing", "Listing");
            objbulk.ColumnMappings.Add("Availability", "Availability");
            objbulk.ColumnMappings.Add("Availability of product title", "Availability of product title");
            objbulk.ColumnMappings.Add("Availability of brand name in title", "Availability of brand name in title");
            objbulk.ColumnMappings.Add("Title should have >6 words", "Title should have >6 words");
            objbulk.ColumnMappings.Add("Availability of product description", "Availability of product description");
            objbulk.ColumnMappings.Add("Desciption should have >15 words", "Desciption should have >15 words");
            objbulk.ColumnMappings.Add("Availability of specifications", "Availability of specifications");
            objbulk.ColumnMappings.Add("No# of specifications (>5)", "No. of specifications (>5)");
            objbulk.ColumnMappings.Add("Availability of image", "Availability of image");
            objbulk.ColumnMappings.Add("No# Of Images", "No. Of Images");
            objbulk.ColumnMappings.Add("No# of images (>3)", "No. of images (>3)");
            objbulk.ColumnMappings.Add("Availability of customer reviews", "Availability of customer reviews");
            objbulk.ColumnMappings.Add("No# of customer reviews (>21)", "No. of customer reviews (>21)");
            objbulk.ColumnMappings.Add("No# Of Customer Reviews", "No. Of Customer Reviews");
            objbulk.ColumnMappings.Add("Availability of product rating", "Availability of product rating");
            objbulk.ColumnMappings.Add("Product rating >4", "Product rating >4");
            objbulk.ColumnMappings.Add("Availability of Seller", "Availability of Seller");
            objbulk.ColumnMappings.Add("Availability of breadcrumbs", "Availability of breadcrumbs");
            objbulk.ColumnMappings.Add("Overall Score", "Overall Score");
            objbulk.ColumnMappings.Add("Compliance Status", "Compliance Status");
            objbulk.ColumnMappings.Add("URL", "URL");
            objbulk.ColumnMappings.Add("Cache Page Link", "Cache Page Link");
            objbulk.ColumnMappings.Add("Number of words in title", "Number of words in title");
            objbulk.ColumnMappings.Add("No# of words in description", "No. of words in description");
            objbulk.ColumnMappings.Add("No  of bullets", "No  of bullets");
            objbulk.ColumnMappings.Add("Product description", "Product description");
            objbulk.ColumnMappings.Add("Specifications / bullets", "Specifications / bullets");
            objbulk.ColumnMappings.Add("Trusted product description", "Trusted product description");
            objbulk.ColumnMappings.Add("Trusted title", "Trusted title");
            objbulk.ColumnMappings.Add("Trusted ratings", "Trusted ratings");
            objbulk.ColumnMappings.Add("Trusted reviews", "Trusted reviews");
            objbulk.ColumnMappings.Add("Video availability", "Video availability");
            objbulk.ColumnMappings.Add("Color grouping", "Color grouping");
            objbulk.ColumnMappings.Add("Sustainability", "Sustainability");
            objbulk.ColumnMappings.Add("Product rating vs trusted source", "Product rating vs trusted source");
            objbulk.ColumnMappings.Add("No# of reviews vs trusted source", "No. of reviews vs trusted source");

            con.Open();
            objbulk.WriteToServer(dt);
            using (SqlCommand cmd2 = new SqlCommand("InsertIntoFileUploadLog", con))
            {
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Filename", filename);
                cmd2.Parameters.AddWithValue("@UploadedOn", DateTime.Now);
                cmd2.Parameters.AddWithValue("@Status", "1");
                cmd2.ExecuteNonQuery();
            }

        }
        [HttpGet]
        public ActionResult Login()
        {
            HttpCookie cookie = new HttpCookie("TestCookie");
            cookie.Value = "This is a TestCookie";
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return View();
            /* if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
              {
                  UserName = Request.Cookies["UserName"].Value;
                 // Password = Request.Cookies["Password"].Value;
                  Password.Attributes.Add("value", Request.Cookies["Password"].Value);
             }*/

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["ExcelData"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("usp_LoginDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", login.UserName);
                    cmd.Parameters.AddWithValue("@Password", login.Password);

                    con.Open();
                    SqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        FormsAuthentication.SetAuthCookie(login.UserName, true);
                        Session["UserName"] = login.UserName.ToString();
                       

                        return RedirectToAction("Index");
                    }
                    else
                    {                       
                        ViewData["message"] = "Incorrect Credentials";
                        ViewBag.Error = "Please Enter Correct Credentials";
                    }

                   
                    // if (login.RememberMe.Checked)
                    // {
                    //Storing UserName
                    //Response.Cookies.Add(new HttpCookie("UserName", login.UserName));
                    //Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(1);

                        //Storing Password
                       // Response.Cookies.Add(new HttpCookie("Password", login.Password));
                       // Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(1);
                   //}
                     if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("TestCookie"))
                     {
                         HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["TestCookie"];

                         ViewBag.CookieMessage = cookie.Value;
                     }
                    // Response.Redirect($"HiddenField.cs?UserName={login.UserName}");

                    con.Close();
                    return View();
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}