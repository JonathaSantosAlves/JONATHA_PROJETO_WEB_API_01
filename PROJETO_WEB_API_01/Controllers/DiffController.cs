using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using JONATHA_PROJETO_WEB_API_01_DOMAIN;
using JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface;
using System.Text;

namespace JONATHA_PROJETO_WEB_API_01.Controllers
{
    [Route("v1/diff/{id}")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private static readonly Dictionary<int, DiffData> _data = new Dictionary<int, DiffData>();

        private readonly ILeftValue _leftvalue;
        private readonly IRightValue _rightvalue;
        private readonly IGetValue _getvalue;

        public DiffController(ILeftValue leftvalue, IRightValue rightvalue, IGetValue getvalue)
        {
            _leftvalue = leftvalue;
            _rightvalue = rightvalue;
            _getvalue = getvalue;
        }

        [HttpPost("left")]
        public IActionResult Left(int id, [FromBody] string base64Data)
        {
            _leftvalue.CollectValue(id, Convert.ToBase64String(Encoding.UTF8.GetBytes(base64Data)), _data);

            return Ok();
        }

        [HttpPost("right")]
        public IActionResult Right(int id, [FromBody] string base64Data)
        {
            _rightvalue.CollectValue(id, Convert.ToBase64String(Encoding.UTF8.GetBytes(base64Data)), _data);

            return Ok();
        }

        [HttpGet("")]
        public IActionResult Get(int id)
        {
            if (_getvalue.VerifyValueID(id, _data) == false)
            {
                return NotFound(new DiffResult { Alert = "Please enter the correct value" });
            }

            if (_getvalue.VerifyValueLeftRight(id, _data) == false)
            {                
                return BadRequest(new DiffResult { Alert = "Os dados esquerdo e direito são necessários para comparar." });
            }

            var result = _getvalue.ReturnValue(id, _data);

            return Ok(result);
        }
    }
}
