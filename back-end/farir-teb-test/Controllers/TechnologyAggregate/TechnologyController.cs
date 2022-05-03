using Application.Services.TechnologyAggregate;
using Domain.Messages.TechnologyAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace farir_teb_test.Controllers.TechnologyAggregate
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly TechnologyService technologyService;

        public TechnologyController(TechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }

        [HttpGet, ProducesResponseType(typeof(IEnumerable<TechnologyDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await technologyService.GetAll());
        }
    }
}
