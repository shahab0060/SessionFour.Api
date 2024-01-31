using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SessionFour.Api.Entities
{
    public class CarInsurance
    {
        [Key]
        public long Id { get; set; }

        public long CarId { get; set; }

        public long InsuranceId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int PayedPrice { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

        [ForeignKey(nameof(InsuranceId))] 
        public Insurance Insurance { get; set; }
    }

    public class CreateCarInsuranceViewModel
    {
        public long UserId { get; set; }

        public long InsuranceId { get; set; }

        public int Price { get; set; }
    }

    public class ShowCarInsuranceInformationViewModel
    {
        public long Id { get; set; }

        public string CarBrandTitle { get; set; }

        public int Createyear { get; set; }

        public string CarModelTitle { get; set; }

        public string InsuranceTitle { get; set; }

        public int Price { get; set; }

        public DateTime CreateDate { get; set; }


    }
}
