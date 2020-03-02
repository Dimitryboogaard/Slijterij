using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlijterijSL.Models
{
    public class Employees
    {



        public string FirstName { get; set; }

        public string LastName { get; set; }

        /* for hasing data, no idea where to put this yet
         * 
         * var sha1 = new SHA1CryptoServiceProvider();
var sha1data = sha1.ComputeHash(data);

To get data as byte array you could use

var data = Encoding.ASCII.GetBytes(password);

and to get back string from md5data or sha1data

var hashedPassword = ASCIIEncoding.GetString(md5data);
       
      

    */
    }
}
