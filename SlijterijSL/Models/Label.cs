using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlijterijSL.Models
{
    public class Label
    {
        #region Initiate
        public string Name { get; set; }

        public DateTime Age { get; set; }

        public string MadeIn { get; set; }

        // using float here because usually they only use not that high of a prescision
        // example: 18.74%
        public float AlcoholPercentage { get; set; }

        public string KindOf { get; set; }

        // public SByte ImageOfBeverage { get; set; }

        public float Price { get; set; }

        public int Amount { get; set; }

        public bool IsAvailable { get; set; } 
        #endregion




        /* ================================== */

        public static void edit()
        {

        }

    }
}
