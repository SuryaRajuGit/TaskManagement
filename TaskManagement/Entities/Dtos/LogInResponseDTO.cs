using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dtos
{
    public class LogInResponseDTO
    {
        public string access_token { get; set; }

        public string token_type { get; set; }
    }
}
