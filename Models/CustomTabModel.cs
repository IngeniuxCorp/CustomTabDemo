using Ingeniux.CMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace CustomTabDemo.Models
{
    [Export(typeof(ICMSCustomApplicationModel))]
    [ExportMetadata("model", "CustomTabModel")]
    public class CustomTabModel
    {
        public bool IsDebug { get; set; }
        public string UserName { get; set; }
        public IEnumerable<PageDataModel> PageData;
    }
}