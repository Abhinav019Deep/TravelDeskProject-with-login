namespace TravelDeskProject.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> User { get; set; }
    }
}
