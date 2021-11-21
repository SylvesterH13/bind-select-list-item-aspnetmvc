using BindSelectListItem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BindSelectListItem.Controllers
{
    public class HomeController : Controller
    {
        private static BudgetPrepViewModel _budgetPrepViewModel = new BudgetPrepViewModel
        {
            WorksheetRates = new List<WorksheetRate>
            {
                new WorksheetRate
                {
                    Id = 34,
                    Program = "Test 1",
                    Area = "1000",
                    GARateID = 2,
                    OverheadRateID = 4
                },
                new WorksheetRate
                {
                    Id = 5,
                    Program = "Test 2",
                    Area = "2000",
                    GARateID = 3,
                    OverheadRateID = 2
                }
            },
            GARateList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "10" },
                new SelectListItem { Value = "2", Text = "30" },
                new SelectListItem { Value = "3", Text = "70" },
            },
            OverheadRateList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "500" },
                new SelectListItem { Value = "2", Text = "1100" },
                new SelectListItem { Value = "3", Text = "6000" },
                new SelectListItem { Value = "4", Text = "9000" },
            }
        };

        public IActionResult Index()
        {
            return View(_budgetPrepViewModel);
        }

        [HttpPost]
        public IActionResult Index(BudgetPrepViewModel budgetPrepViewModel)
        {
            UpdateBudgetPrepViewModel(budgetPrepViewModel);
            return RedirectToAction(nameof(Index));
        }

        private void UpdateBudgetPrepViewModel(BudgetPrepViewModel budgetPrepViewModel)
        {
            _budgetPrepViewModel.WorksheetRates = _budgetPrepViewModel.WorksheetRates.Select(worksheetRate =>
            {
                var worksheetRateModel = budgetPrepViewModel.WorksheetRates.Single(w => w.Id == worksheetRate.Id);
                worksheetRate.GARateID = worksheetRateModel.GARateID;
                worksheetRate.OverheadRateID = worksheetRateModel.OverheadRateID;
                return worksheetRate;
            })
            .ToList();
        }
    }
}
