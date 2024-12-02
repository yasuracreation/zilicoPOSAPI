using Microsoft.AspNetCore.Mvc;

namespace zilicoPOSAPI.Controllers;
[Route("api/inventory")]
[ApiController]
public class InventoryController :ControllerBase
{
    private ILogger<InventoryController> _logger;
    
}