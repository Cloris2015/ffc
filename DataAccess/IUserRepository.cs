using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        int Create(User user);
        User Get(int Id);
        User Update(User user);
        void Delete(int ID);
        IList<User> Search(string name, string email, string phone);

    }

}
