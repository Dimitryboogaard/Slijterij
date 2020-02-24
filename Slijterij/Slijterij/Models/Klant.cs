using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Slijterij.Models
{
    public class Klant
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }

        public string Email { get; set; }

        public int TelefoonNummer { get; set; }

    }
}