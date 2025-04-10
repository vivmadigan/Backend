using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class AddProjectForm
    {
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Budget { get; set; }

        public string ClientId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int StatusId { get; set; }
    }
}
