using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Pag_demo.Models
{
    public class ApplicationDbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["ExcelData"].ConnectionString;

        public List<FileUploadLog> FileUploadLog { get; set; }
        public List<Login> Login { get; set; }
    }
}