using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    public class License
    {
        
        [Key]
        public int ID { get; set; }

        public string LicenseName { get; set; }

        public string Terms { get; set; }

    }
}
