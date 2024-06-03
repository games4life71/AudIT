using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudiT.Domain.Entities;

namespace AudIT.Domain.Misc
{
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public List<Guid>? WriteAccesUserId { get; set; } = [];

        public List<Guid>? ReadAccesUserId { get; set; } = [];
    }
}