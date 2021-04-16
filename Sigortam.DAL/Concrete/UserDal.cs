using Sigortam.DAl.Concrete;
using Sigortam.DAL.Abstract;
using Sigortam.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Concrete
{
    public class UserDal : Repository<User, SigortamContext>, IUserDal
    {
    }
}
