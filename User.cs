using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_4
{
    public class User
    {
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        public string FullName
        {
            get
            {
                return $"{firstName} {surname}";
            }
        }
    }
}
