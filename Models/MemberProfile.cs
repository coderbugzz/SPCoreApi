using System.ComponentModel.DataAnnotations;

namespace SPCoreApi.Models
{
    public class MemberProfile
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string ContactNumber { get; set; }
        public string Status { get; set; }
    }
}