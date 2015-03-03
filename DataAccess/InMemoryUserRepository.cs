using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;

namespace DataAccess
{
    public class InMemoryUserRepository : IUserRepository
    {
        static Dictionary<int, User> users = new Dictionary<int, User>();
        static InMemoryUserRepository()
        {
            users.Add(1, new User(1) { Email = "john.doe@email.com", Name = "John Doe", Phone = "123-456-7890",BOD=new DateTime(2010,3,10)});
            users.Add(2, new User(2) { Email = "mike.doe@email.com", Name = "Mike Doe", Phone = "123-456-7891",BOD=new DateTime(2011,5,11)});
            users.Add(3, new User(3) { Email = "sally.doe@email.com", Name = "Sally Doe", Phone = "123-456-7892",BOD=new DateTime(1990,1,15)});
        }

        public int Create(DataModel.User user)
        {
            lock (users)
            {
                int id = users.Keys.Max() + 1;
                users.Add(id,new User(id){Email=user.Email,Phone=user.Phone, Name=user.Name,BOD=user.BOD});
                return id;
            }

        }

        public DataModel.User Update(DataModel.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            lock (users)
            {
                if (users.ContainsKey(user.ID))
                {
                    User u = users[user.ID];
                    u.Name = user.Name;
                    u.Phone = user.Phone;
                    u.Email = user.Email;
                    u.BOD = user.BOD;
                    return user;
                }
                else
                {
                    throw new ArgumentException();
                }


            }
        }

        public void Delete(int ID)
        {
            if (users.ContainsKey(ID))
            {
                users.Remove(ID);
            }
        }

        public IList<DataModel.User> Search(string name, string email, string phone)
        {
            return users
                .Where(u => (u.Value.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                    || string.IsNullOrEmpty(u.Value.Name))
                && (u.Value.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(u.Value.Email))
                && (u.Value.Phone.Equals(phone, StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(u.Value.Phone))
                )
                .Select(u => u.Value.Clone()).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return (from u in users select u.Value);
        }
        public User Get(int id)
        {
            return users.ContainsKey(id) ? users[id] : null;
                
        }
    }
}
