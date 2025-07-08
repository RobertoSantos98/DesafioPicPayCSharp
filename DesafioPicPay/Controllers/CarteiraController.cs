using DesafioPicPay.Application.Request;
using DesafioPicPay.Application.Services.CarteiraService;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraService _service;

        public CarteiraController(ICarteiraService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostCarteira(CarteiraRequest request)
        {
            var result = await _service.ExecuteAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created();

        }

    }
}
