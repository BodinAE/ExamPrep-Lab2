using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class ClientName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronym { get; set; }
        public ClientName (string last, string first, string patr)
        {
            LastName = last;
            FirstName = first;
            Patronym = patr;
        }
        public ClientName (string fullname)
        {
            var name = fullname.Split(' ');
            FirstName = name[0];
            LastName = name[1];
            Patronym = name[2];
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {Patronym}";
        }
    }
}
