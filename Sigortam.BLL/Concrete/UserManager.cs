using Sigortam.BLL.Abstract;
using Sigortam.Core.Model;
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

        public override CResult<User> Add(User entity)
        {
            var user = Get(c => c.StPlaka == entity.StPlaka && c.StTCKN == entity.StTCKN);
            //Daha önce eklenmiş ise tekrar eklenmesin.
            if (user==null)
            {
                return base.Add(entity);
            }
            return new CResult<User>();
        }
    }
}
