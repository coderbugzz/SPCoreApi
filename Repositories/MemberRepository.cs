using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SPCoreApi.Models;

namespace SPCoreApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDBContext _context;
        public MemberRepository(AppDBContext context)
        {
            _context = context;

        }
        public async Task<int> CreateMemberAsync(MemberProfile member)
        {
         

         var parameter = new List<SqlParameter>();
         parameter.Add(new SqlParameter("@emailAddress", member.EmailAddress));
         parameter.Add(new SqlParameter("@userName", member.EmailAddress));
         parameter.Add(new SqlParameter("@contactNumber", member.EmailAddress));
         parameter.Add(new SqlParameter("@Status", member.EmailAddress));
         parameter.Add(new SqlParameter{
             ParameterName = "@retVal",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
         });

            
          var result = await Task.Run(()=>_context.MemberProfiles.FromSqlRaw(@"exec sp_CreateMember 
                                                            @emailAddress,
                                                            @userName,
                                                            @contactNumber,
                                                            @Status,
                                                            @retVal OUT",
                                                            parameter.ToArray()
                                                            ));

           int retVal = int.Parse(parameter[4].Value.ToString()); //get @retVal return value
           return retVal;
        }

        public async Task<List<MemberProfile>> GetAlleMemberAsync()
        {
            List<MemberProfile> members = new List<MemberProfile>();
            var result = await _context.MemberProfiles.FromSqlRaw(@"exec sp_GetMembers").ToListAsync();
             
              foreach(var row in result)
              {
                  members.Add(new MemberProfile{
                      Id = row.Id,
                      EmailAddress = row.EmailAddress,
                      UserName = row.UserName,
                      ContactNumber = row.ContactNumber,
                      Status = row.Status
                  });
              }
            return members;
        }

    }
}