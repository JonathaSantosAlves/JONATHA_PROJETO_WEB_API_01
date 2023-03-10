using Microsoft.AspNetCore.Mvc;
using JONATHA_PROJETO_WEB_API_01_DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface
{
    public interface IGetValue
    {
        bool VerifyValueID(int id, Dictionary<int, DiffData> _data);
        bool VerifyValueLeftRight(int id, Dictionary<int, DiffData> _data);
        public DiffResult ReturnValue(int id, Dictionary<int, DiffData> _data);
    }
}
