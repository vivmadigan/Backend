using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class UpdateProjectForm
    {
        [Required(ErrorMessage = "You should provide a project id value.")]
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(80)]
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Budget { get; set; }
        [Required]
        public string ClientId { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public int StatusId { get; set; }

    }
}
