using Love.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Love.Server
{
    public class Database
    {
        public static Database Instance { get; } = new Database();

        public IList<Pet> Pets { get; } = new List<Pet>();
    }

}
