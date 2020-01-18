using System;
using System.Collections.Generic;

namespace HelpDesk.Web.MVC.ViewModels
{
    public class SearchFormViewModel
    {
        public string DocNo { get; set; }

        public string DeptNo { get; set; }

        public string Type { get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime CloseTime { get; set; }
        
        public IList<string> ShowItems { get; set; }
    }
}