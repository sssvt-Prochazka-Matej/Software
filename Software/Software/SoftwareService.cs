using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Software
{
    public class SoftwareService
    {

        MyContext context = new MyContext();
        public List<Software> GetList()
        {
            List<Software> list = new List<Software>();

            list = context.tb_Software.ToList();
            
            return list;
        }
        

        public void Add(Software software)
        {
            context.tb_Software.Add(software);

            context.SaveChanges();
        }

        public void Delete(Software software)
        {
            context.Entry(software).State = EntityState.Deleted;

            context.SaveChanges();
        }

        public void Update(Software license)
        {
            context.Entry(license).State = ((license.ID == 0) ? (EntityState.Added) : (EntityState.Modified));

            context.SaveChanges();
        }
    }
}
