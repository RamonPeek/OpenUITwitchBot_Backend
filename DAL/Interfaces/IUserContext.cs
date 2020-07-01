using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserContext : ICRUD<User>
    {
    }
}
