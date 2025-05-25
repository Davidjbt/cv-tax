using System.ComponentModel.DataAnnotations;

namespace cv_tax.Models {
    public class TaxCalculatorModel {

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Must be positive.")] // 79228162514264337593543950335 is the max value of decimal
        [RegularExpression("(?=.*?\\d)^\\$?(([1-9]\\d{0,2}(,\\d{3})*)|\\d+)?(\\.\\d{1,2})?$", ErrorMessage = "Please enter a valid decimal.")]
        public decimal Income { get; set; }

        [Required]
        public SalaryInterval SalaryInterval { get; set; }
        public int TaxRate { get; set; }
        public decimal TotalTax { get; set; }
    }

    public enum SalaryInterval {
        Monthly, Annually
    }

}
