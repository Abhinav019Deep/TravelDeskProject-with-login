using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelDeskProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }        
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public DateTime? UpdatedOn { get; set;}
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public User? user { get; set; }

    }
}
