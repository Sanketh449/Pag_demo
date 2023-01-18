using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pag_demo.Models
{
    public class FileUploadLog
    {
        public int ID { get; set; }
        public string FileName { get; set; }

        public String UploadedOn { get; set; }

        public string Status { get; set; }
    }
}