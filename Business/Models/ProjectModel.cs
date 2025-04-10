using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProjectModel
    {
        public string Id { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Budget { get; set; }

        public ClientModel? Client { get; set; } = null!;
        public UserModel? User { get; set; } = null!;
        public StatusModel? Status { get; set; } = null!;
    }
}
