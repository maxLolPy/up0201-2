using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up0201
{
    public class User
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string secondname { get; set; }
        public string login { get; set; }
        public string roul { get; set; }
        public string phone { get; set; }
        public string pol { get; set; }
        public object photo { get; set; }

        public User (string srnme, string nme, string scndnme, string lgn, string rl, string phne, string pl, object phto)
        {
            surname = srnme;
            name = nme;
            secondname = scndnme;
            login = lgn;
            roul = rl;
            phone = phne;
            pol = pl;
            photo = phto;
        }
    }
}
