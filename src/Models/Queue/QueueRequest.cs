using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Queue
{
    public class QueueRequest
    {
        public int? PatientId { get; set; }
        public string? Section { get; set; }
        public string? QrCodeBase64 { get; set; }
    }
}
