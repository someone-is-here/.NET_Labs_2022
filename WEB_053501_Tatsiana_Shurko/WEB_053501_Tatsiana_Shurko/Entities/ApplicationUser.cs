using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using WEB_053501_Tatsiana_Shurko.Data;
using System.Threading.Tasks;

namespace WEB_053501_Tatsiana_Shurko.Entities {
    [NotMapped]
    public class ApplicationUser : IdentityUser {
        public byte[]? Image { get; set; }
        public string? ContentType { get; set; }
        public void InitializeArray(int length) { 
            Image = new byte[length];
        }
    }
}
