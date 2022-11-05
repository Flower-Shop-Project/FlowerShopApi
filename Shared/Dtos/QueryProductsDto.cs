using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class QueryProductsDto
    {
        public string? FlowerType { get; set; }
        public string? Appointment { get; set; }
        public string? Type { get; set; }
        public string? Query { get; set; }
    }
}
