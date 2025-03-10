using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class RoleService
    {

        RoleRepo RoleRepo;

        public RoleService()
        {
            RoleRepo = new RoleRepo();

        }

        public List<Role> GetRoles()
        {
            return RoleRepo.Roles();
        }
    }
}
