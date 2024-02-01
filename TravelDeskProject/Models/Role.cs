namespace TravelDeskProject.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
