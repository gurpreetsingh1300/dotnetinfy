using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartDataAccessLayer
{
    public class QuickKartRepository
    {
        private QuickKartDBContext Context { get; set; }
        public QuickKartRepository()
        {
            Context = new QuickKartDBContext();
        }

        public string ValidateLoginUsingLinq(string emailId, string password)
        {
            var objUser = (from usr in Context.Users
                           where usr.EmailId == emailId && usr.UserPassword == password
                           select usr).FirstOrDefault<User>();
        }
    }
}
