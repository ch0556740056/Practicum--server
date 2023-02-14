using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class ChildDto
    {
        public string Identity { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateTime DateOfBirdth { get; set; }

        public string ParentId { get; set; } = null!;

    }
}
