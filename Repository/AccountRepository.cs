using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class AccountRepository : GeneralRepository<MyContext, Account, String>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Login(LoginVM loginVM)
        {
            try
            {
                var emp = myContext.Employees.FirstOrDefault(e => e.Email == loginVM.email);
                if (emp == null)
                {
                    return 3;
                }

                var acc = myContext.Accounts.FirstOrDefault(a => a.NIK == emp.NIK);

                var emailValidation = emp.Email == loginVM.email;
                var passwordValidation = BCrypt.Net.BCrypt.Verify(loginVM.password, acc.password);

                if (emailValidation && passwordValidation)
                {
                    return 1;
                }
                else if (emailValidation && !passwordValidation)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
