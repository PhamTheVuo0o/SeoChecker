using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASW.SM.Core.Domain.Models
{
    public class SeoPostionModel
    {
        public string Provider { get; set; } = "";
        public List<int> Positions { get; set; } = new List<int>();
    }
}
