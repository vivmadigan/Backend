﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enitities
{
    public class ClientEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ClientName { get; set; } = null!;
        public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
    }
}
