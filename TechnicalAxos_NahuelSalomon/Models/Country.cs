using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_NahuelSalomon.Models
{
    public class Country
    {
        public CountryName Name { get; set; }
        public bool Independent { get; set; }
        public List<string> Capital { get; set; }
        public List<string> Continents { get; set; }
        public CountryFlag Flags { get; set; }

        public string FirstContinent { get { return Continents.FirstOrDefault()!; } }
        public string FirstCapital { get { return Capital.FirstOrDefault()!; } }
    }
}
