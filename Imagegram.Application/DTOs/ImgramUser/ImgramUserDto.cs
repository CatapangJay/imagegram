using Imagegram.Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Imagegram.Application.DTOs.ImgramUser
{
    public class ImgramUserDto : BaseDto
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Username { get; set; }
    }
}