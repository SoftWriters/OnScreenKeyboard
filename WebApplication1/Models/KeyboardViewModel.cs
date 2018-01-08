using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class KeyboardViewModel
    {
        [Display(Name = "DVR Program Sequance")]
        public string DvrProgramming { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [Display(Name = "File Contents")]
        public string FileContents { get; set; }
    }
}