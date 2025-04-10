using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enitities
{
    public class ProjectEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public decimal? Budget { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = null!;
        public virtual ClientEntity Client { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public virtual StatusEntity Status { get; set; } = null!;
    }
}
