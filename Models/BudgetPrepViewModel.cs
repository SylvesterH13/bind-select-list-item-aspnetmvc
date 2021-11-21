using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BindSelectListItem.Models
{
    public class BudgetPrepViewModel
    {
        public List<WorksheetRate> WorksheetRates { get; set; }

        public IEnumerable<SelectListItem> GARateList { get; set; }
        public IEnumerable<SelectListItem> OverheadRateList { get; set; }
    }
}
