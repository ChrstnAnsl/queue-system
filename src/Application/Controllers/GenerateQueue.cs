using FastEndpoints;
using Models.Queue;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Application.Utils; // Ensure this is the correct namespace
using DTO.Queue;

namespace Application.Controllers
{
    public class GenerateQueue : Endpoint<QueueRequest, QueueResponse>
    {
        private readonly ILogger<GenerateQueue> _logger;

        public GenerateQueue(ILogger<GenerateQueue> logger)
        {
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/queue/generate-queue");
            AllowAnonymous();
            Description(b => b
                .Accepts<QueueRequest>("application/json")
                .Produces<QueueResponse>(200, "application/json"),
            clearDefaults: true);
            Summary(s => {
                s.Summary = "Generate Queue ID";
                s.Description = "long description goes here";
                s.Responses[200] = "ok response description goes here";
                s.Responses[403] = "forbidden response description goes here";
            });
        }

        public override async Task HandleAsync(QueueRequest req, CancellationToken ct)
        {
            try
            {
                _logger.LogInformation("Generating queue for PatientId: {PatientId}, Section: {Section}", req.PatientId, req.Section);

                var response = new QueueResponse
                {
                    PatientId = req.PatientId,
                    PatientName = "Ansel Fernandez",
                    Section = req.Section,
                    QueueId = Util.GenerateTimeBasedGuid(),
                    Created = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"),
                    QrCodeBase64 = req.QrCodeBase64
                };

                await SendAsync(response, cancellation: ct).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating queue");
                await SendErrorsAsync(500, cancellation: ct).ConfigureAwait(false);
            }
        }
    }
}
