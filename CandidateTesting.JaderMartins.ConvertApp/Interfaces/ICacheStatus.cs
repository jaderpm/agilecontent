using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Interfaces
{
    public interface ICacheStatus
    {
        string GetCacheStatus(List<string> columns);
    }
}
