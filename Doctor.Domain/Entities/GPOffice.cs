using Surgery.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surgery.Domain.Entities
{
    public class GPOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public GPOffice(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
              throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            Name = name;
            Id = Guid.CreateVersion7();
        }
    
    }
}
