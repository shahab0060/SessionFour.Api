using System.ComponentModel.DataAnnotations;

namespace SessionFour.Api.Entities
{
    public class Insurance
    {
        [Key]
        public long Id { get; set; }

        public string   Title { get; set; }

        public Brand CarBrand { get; set; }

        public int Price { get; set; }

        public ICollection<CarInsurance> Cars { get; set; }
    }
}
