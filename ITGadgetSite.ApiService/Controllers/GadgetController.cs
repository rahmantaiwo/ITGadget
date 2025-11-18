using ITGadgetSite.BL;
using ITGadgetSite.BL.DTOs;
using ITGadgetSite.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITGadgetSite.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetController(IGadgetService gadgetService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGadget(CancellationToken cancellationToken)
        {
            var result = await gadgetService.GetAllGadgetAsync(cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateGadget([FromBody] CreateGadgetDto request, CancellationToken cancellationToken)
        //{
        //    var response = await gadgetService.CreateGadgetAsync(request, cancellationToken);

        //    return StatusCode(response.StatusCode, response);
        //}

        //[HttpPut("{gadgetId}")]
        //public async Task<IActionResult> UpdateGadget([FromRoute] Guid gadgetId, CreateGadgetDto request, CancellationToken cancellationToken)
        //{
        //    var response = await gadgetService.UpdateGadgetAsync(gadgetId, request, CancellationToken.None);
        //    return StatusCode(response.StatusCode, response);
        //}


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGadgetById([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var response = await gadgetService.GetGadgetByIdAsync(id, cancellationToken);
        //    return StatusCode(response.StatusCode, response);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteGadget([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var response = await gadgetService.DeleteGadgetAsync(id, cancellationToken);
        //    return StatusCode(response.StatusCode, response);
        //}
    }
}
