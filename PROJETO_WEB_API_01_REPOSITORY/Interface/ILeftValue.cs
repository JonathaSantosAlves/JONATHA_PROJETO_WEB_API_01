using Microsoft.AspNetCore.Mvc;
using JONATHA_PROJETO_WEB_API_01_DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface
{
    public interface ILeftValue
    {
        void CollectValue(int id, [FromBody] string base64Data, Dictionary<int, DiffData> _data);
    }
}
