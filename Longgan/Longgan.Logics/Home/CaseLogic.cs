using Longgan.DataAccess.Home;
using Longgan.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longgan.Logics.Home
{
    public class CaseLogic : Logic
    {
        CaseDA da = new CaseDA();
        public List<SetCase> GetCases()
        {
            return da.GetCases();
        }

        public SetCase GetCase(string Id)
        {
            return da.GetCase(Id);
        }

        public List<SetCase> GetCasesPaging(int pageIndex, int pageSize, ref int totalCount)
        {
            List<SetCase> cases = this.GetCases();
            var profilesPage = cases.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            totalCount = cases.Count();
            return profilesPage.ToList();
        }
    }
}
