using Microsoft.EntityFrameworkCore;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;

namespace TravelDeskProject.Repo
{
    public class UserRepo:IUserRepo
    {
        TravelDbContext _db;
        public UserRepo(TravelDbContext db)
        {
            _db = db;
        }
        public void Add(User user)
        {
            user.IsActive = true;
            _db.Users.Add(user);
            _db.SaveChanges();

        }
        public User GetUser(int id) 
        { 
            return _db.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
        public List<User> AllUsers()
        {
            return _db.Users.Where(x=>x.IsActive == true).ToList();
        }

        public void DeleteUser(int id)
        {
            User user=_db.Users.Where(x=>x.UserId == id).FirstOrDefault();
            user.IsActive = false;
            _db.SaveChanges();
        }
        public void EditUser(int id,User user)
        {
            var data = _db.Users.Where(e => e.UserId == id).FirstOrDefault();
            if (data != null)
            { 
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.Password = user.Password;
                data.Address = user.Address;
                data.MobileNumber = user.MobileNumber;
                data.CreateBy = user.CreateBy;
                data.CreatedOn = user.CreatedOn;
                data.UpdateBy = user.UpdateBy;
                data.UpdatedOn = user.UpdatedOn;
                data.IsActive = user.IsActive;              
                data.RoleId = user.RoleId;
                data.ManagerId = user.ManagerId;
                data.DepartmentId = user.DepartmentId;
                _db.Users.Update(data);
                _db.SaveChanges();
            }
        }

       

        }
    }

