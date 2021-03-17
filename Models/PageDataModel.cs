using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomTabDemo.Models
{
    public class PageDataModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool HasSEOTitle { get; set; }
        public bool HasSEODescription { get; set; }
        public bool HasSEOKeywords { get; set; }
    }
}