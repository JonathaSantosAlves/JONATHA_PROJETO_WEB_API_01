using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JONATHA_PROJETO_WEB_API_01_DOMAIN
{
    public class DiffData
    {
        public int Id { get; set; }
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
    }
}
