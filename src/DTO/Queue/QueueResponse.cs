using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Queue
{
    public class QueueResponse
    {
        public int? PatientId { get; set; }
        public string? PatientName { get; set;}
        public string? QueueId { get; set; }
        public string? Section { get; set; }
        public string? Created { get; set; }
        public string? QrCodeBase64 { get; set; }
    }
}
