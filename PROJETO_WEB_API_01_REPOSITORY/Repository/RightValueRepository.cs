using Microsoft.AspNetCore.Mvc;
using JONATHA_PROJETO_WEB_API_01_DOMAIN;
using JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JONATHA_PROJETO_WEB_API_01_REPOSITORY.Repository
{
    public class RightValueRepository : IRightValue
    {
        public void CollectValue(int id, [FromBody] string base64Data, Dictionary<int, DiffData> _data)
        {
            if (!_data.ContainsKey(id))
            {
                _data.Add(id, new DiffData { Id = id });
            }

            _data[id].Data["right"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(base64Data));
        }
    }
}
