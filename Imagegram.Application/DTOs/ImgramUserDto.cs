using Imagegram.Application.DTOs.Common;

namespace Imagegram.Application.DTOs
{
    public class ImgramUserDto : BaseDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}