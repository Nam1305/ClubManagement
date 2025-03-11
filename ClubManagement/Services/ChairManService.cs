using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class ChairManService
    {
        ChairmanRepo repo;

        public ChairManService()
        {
            repo = new ChairmanRepo();
        }

        public List<object> GetUsers(int ?clubId) {
            return repo.GetUsers(clubId);
        }


    }
}
