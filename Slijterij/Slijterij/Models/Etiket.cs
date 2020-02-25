using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij.Models
{
    public class Etiket
    {
        #region Casting
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int ID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        public DateTime Age { get; set; }

        public string MadeIn { get; set; }

        //[Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        //public string Discription { get; set; }

        // using float here because usually they only use not that high of a prescision
        // example: 18.74%
        public float AlcoholPercentage { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int Amount { get; set; }

        public bool IsAvailable { get; set; }
        #endregion

    }
}