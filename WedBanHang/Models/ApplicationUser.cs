using Microsoft.AspNetCore.Identity;
using WedBanHang.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string? Address { get; set; }
    public string? Age { get; set; }
    public ICollection<Order> Orders { get; set; }
}

