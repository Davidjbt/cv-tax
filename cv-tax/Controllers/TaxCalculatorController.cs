using cv_tax.Models;
using Microsoft.AspNetCore.Mvc;

namespace cv_tax.Controllers {
    public class TaxCalculatorController : Controller {

        public IActionResult Index() {
            return View(new TaxCalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(TaxCalculatorModel model) {
            if (ModelState.IsValid) {

                if (model.SalaryInterval.Equals(SalaryInterval.Monthly)) {
                    model.Income = model.Income * 12;
                }

                if (model.Income <= 12_570) {
                    model.TaxRate = 0;
                    model.TotalTax = 0;
                }
                else if (12_570 < model.Income && model.Income <= 50270) {
                    model.TaxRate = 20;
                    model.TotalTax = 0.2m * (model.Income - 12_570);
                }
                else if (50270 < model.Income && model.Income <= 125_140) {
                    model.TaxRate = 40;
                    model.TotalTax = 0.2m * (50270 - 12_570) + 0.4m * (model.Income - 50270);
                }
                else {
                    model.TaxRate = 45;
                    model.TotalTax = 0.2m * (50270 - 12_570) + 0.4m * (125_140 - 50270) + 0.4m * (model.Income - 125_140);
                }
            }
            
            return View(model);
        }

    }
}
