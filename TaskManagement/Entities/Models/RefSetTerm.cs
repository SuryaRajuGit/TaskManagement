using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class RefSetTerm
    {
        public Guid Id { get; set; }

        public Guid RefSetId { get; set; }
        public RefSet RefSet { get; set; }

        public Guid RefTermId { get; set; }
        public RefTerm RefTerm { get; set; }
    }
}
