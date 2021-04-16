using Sigortam.BLL.Abstract;
using Sigortam.DAL.Abstract;
using Sigortam.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.BLL.Concrete
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        public UserManager(IUserDal InitContext) : base(InitContext)
        {
        }
    }
}
