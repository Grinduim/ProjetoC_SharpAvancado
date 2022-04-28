using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    public void registerClient( ClientDTO cliete){
        
    }
    [HttpGet]
    [Route("GetInformations")]
    public int getInformations(int ClientID){
        return 3;
    }
}