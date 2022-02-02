using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedFilesCloudMigrationUtility.Models
{
    public class LogIn
    {
        [Required]
        [Display(Name = "Server Name")]
        public string  ServerName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
       
        [Display(Name = "Database")]
        public string Source { get; set; }

        public string Files { get; set; }

    }
}