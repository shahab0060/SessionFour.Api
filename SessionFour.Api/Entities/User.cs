using System.ComponentModel.DataAnnotations;

namespace SessionFour.Api.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
