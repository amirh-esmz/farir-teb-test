using Application.Services.CandidateAggregate;
using Domain.Messages.CandidateAggregate;
using Domain.Models.CandidateAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace farir_teb_test.Controllers.CandidateAggregate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService candidateStatusService;

        public CandidateController(CandidateService candidateStatusService)
        {
            this.candidateStatusService = candidateStatusService;
        }

        [HttpGet, ProducesResponseType(typeof(IEnumerable<CandidateDto>), 200)]
        public async Task<IActionResult> GetCandidates([FromQuery] CandidateFilter filter)
        {
            return Ok(await candidateStatusService.GetCandidates(filter));
        }

        [HttpPost("{id}/SetStatus")]
        public async Task<IActionResult> SetStatus(Guid id, bool isAccepted)
        {
            var (isSucceed, message) = await candidateStatusService.SetStatus(id, isAccepted);

            if (isSucceed)
                return Ok();
            else
                return BadRequest(message);
        }
    }
}
