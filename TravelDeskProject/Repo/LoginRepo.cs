using TravelDeskProject.IRepo;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.Repo
{
    public class LoginRepo : ILoginRepo
    {
        TravelDbContext _db;
        public LoginRepo(TravelDbContext db)
        {
            _db = db;
        }
        public bool Login(LoginViewModel loginuser)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == loginuser.Email);
            if(user == null)
            {
                return false;
            }
            else
            {
                if(user.Password == loginuser.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
