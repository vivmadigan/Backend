using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enitities
{
    public class StatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
    }
}
