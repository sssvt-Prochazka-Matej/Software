using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    public class Software
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        public int Version { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public int LicenseID { get; set; }



    }
}
