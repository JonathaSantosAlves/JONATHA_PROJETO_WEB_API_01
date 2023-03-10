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
    public class GetValueRepository: IGetValue
    {
        private string? leftData = "";
        private string? rightData = "";

        public bool VerifyValueID(int id, Dictionary<int, DiffData> _data)
        {
            if (!_data.ContainsKey(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerifyValueLeftRight(int id, Dictionary<int, DiffData> _data)
        {
            ReturnLeftRight(id, _data);

            if (string.IsNullOrEmpty(leftData) || string.IsNullOrEmpty(rightData))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DiffResult ReturnValue(int id, Dictionary<int, DiffData> _data)
        {
            ReturnLeftRight(id, _data);

            var result = new DiffResult
            {
                Equal = leftData == rightData
            };

            if (!result.Equal)
            {
                if (leftData.Length != rightData.Length)
                {
                    result.Alert = "Os dados não possuem o mesmo tamanho.";
                }
                else
                {
                    var diffInfo = new List<DiffInfo>();

                    for (int i = 0; i < leftData.Length;)
                    {
                        if (leftData[i] != rightData[i])
                        {
                            var info = new DiffInfo { Offset = i, Length = 1 };
                            for (int j = i + 1; j < leftData.Length && leftData[j] != rightData[j]; j++)
                            {
                                info.Length++;
                            }
                            diffInfo.Add(info);
                            i += info.Length;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    result.Alert = diffInfo;
                }
            }

            if (result.Equal)
            {
                result.Alert = "OK";
            }

            return result;
        }

        private void ReturnLeftRight(int id, Dictionary<int, DiffData> _data)
        {
            leftData = _data[id].Data.GetValueOrDefault("left");
            rightData = _data[id].Data.GetValueOrDefault("right");
        }
    }
}
