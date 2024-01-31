using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SessionFour.Api.Entities
{
    public class Car : CreateCarViewModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<CarInsurance> Insurances { get; set; }
    }

    public class CreateCarViewModel
    {
        public string Plate { get; set; }

        public string OwnerNatinoalCode { get; set; }

        public string Type { get; set; }

        public int CreateYear { get; set; }

        public Usage Usage { get; set; }

        public Brand Brand { get; set; }

        public Model Model { get; set; }

        public FuelType FuelType { get; set; }

        public DateTime CreateDate { get; set; }

        public long UserId { get; set; }
    }

    public enum Usage
    {
        Personal,
        Taxi,
    }

    public enum Brand
    {
        Dena,
        Pride,
        Peugout
    }

    public enum Model
    {
        Normal,
        Plus
    }

    public enum FuelType
    {
        Gas,
        Oil
    }
}
