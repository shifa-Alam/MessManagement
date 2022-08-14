using Microsoft.EntityFrameworkCore;
using MessManagement.Web.Data;
namespace MessManagement.Web
{
    public class Member : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        public string HomeDistrict { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}