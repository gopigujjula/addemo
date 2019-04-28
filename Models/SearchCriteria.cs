using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Models
{
    public class SearchCriteria
    {
        public string Language { get; set; }
        public List<string> TemplateIds { get; set; }
        public Item RootItem { get; set; }
        public string SearchText { get; set; } = string.Empty;
        public List<Refinement> Refinements { get; set; } = null;
        public string SortFieldName { get; set; } = string.Empty;
        public bool SortAscending { get; set; } = false;
        public int? PageNumber { get; set; } = null;
        public int? PageSize { get; set; } = null;
    }
}