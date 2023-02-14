using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO_s
{
    public class PersonalDetailDto
    {
        public string Identity { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Gender { get; set; }

        public string? Hmo { get; set; }

        public DateTime? DateOfBirdth { get; set; }

    }
}
