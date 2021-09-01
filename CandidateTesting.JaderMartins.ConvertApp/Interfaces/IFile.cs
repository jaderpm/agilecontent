using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Interfaces
{
    public interface IFile
    {
        public List<string> GetLines(string url);
        public List<string> GetColuns(string line);
    }
}
