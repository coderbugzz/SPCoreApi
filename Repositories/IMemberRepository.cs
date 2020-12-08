using System.Collections.Generic;
using System.Threading.Tasks;
using SPCoreApi.Models;

namespace SPCoreApi.Repositories
{
    public interface IMemberRepository
    {
          Task<int> CreateMemberAsync(MemberProfile member);
          Task<List<MemberProfile>> GetAlleMemberAsync();

    }
}