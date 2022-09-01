using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Common
{
    public class BaseForUpdateDto
    {
        [Required(ErrorMessage = "Is is a required field")]
        public int Id { get; set; }
    }
}
