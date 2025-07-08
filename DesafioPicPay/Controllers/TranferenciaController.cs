using DesafioPicPay.Application.Request;
using DesafioPicPay.Application.Services.TransacaoService;
using DesafioPicPay.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranferenciaController : ControllerBase
    {
        private readonly ITrasacaoService _service;

        public TranferenciaController(ITrasacaoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(TransacaoRequest request)
        {
            var result = await _service.Execute(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);

        }


    }
}
