using Longgan.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longgan.DataAccess.Home
{
    public class CaseDA : GenericRepository<SetCase>
    {
        public List<SetCase> GetCases()
        {
            return base.Get().OrderByDescending(p => p.PriorityNum).ToList();
        }

        public SetCase GetCase(string Id)
        {
            return base.Get(p => p.Id == Id).FirstOrDefault();
        }
    }
}
