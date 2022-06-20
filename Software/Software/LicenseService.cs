using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    public class LicenseService
    {
        MyContext context = new MyContext();
        public List<License> GetList()
        {
            List<License> list = new List<License>();

            list = context.tb_License.ToList();

            return list;
        }

        public int GetLicenseId(string name)
        {
            List<License> list = GetList();

            foreach(var item in list)
            {
                if(item.LicenseName == name)
                {
                    return item.ID;
                }
            }
            return 0;
        }

        public string GetLicenseName(int id)
        {
            List<License> list = GetList();

            foreach (var item in list)
            {
                if (item.ID == id)
                {
                    return item.LicenseName;
                }
            }
            return "";
        }


        public void Add(License license)
        {
            context.tb_License.Add(license);

            context.SaveChanges();
        }

        public void Delete(License license)
        {
            context.Entry(license).State = EntityState.Deleted;

            context.SaveChanges();
        }

        public void Update(License license)
        {
            context.Entry(license).State = ((license.ID == 0) ? (EntityState.Added) : (EntityState.Modified));

            context.SaveChanges();
        }
    }
}
