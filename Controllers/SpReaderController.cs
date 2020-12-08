using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPCoreApi.Models;
using SPCoreApi.Repositories;

namespace SPCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpReaderController : ControllerBase
    {
        private readonly IMemberRepository _repository;
        public SpReaderController(IMemberRepository repository)
        {
            _repository = repository;

        }
       [HttpGet]
      public async Task<ActionResult<MemberProfile>> GetAllMember()
      {
          var result = await _repository.GetAlleMemberAsync();
          return Ok(result);
      }

      [HttpPost("CreateMember")]
      public async Task<ActionResult<int>> CreateMember(MemberProfile member)
      {
          var result = await _repository.CreateMemberAsync(member);
          return  Ok(result);
      }
    }
}