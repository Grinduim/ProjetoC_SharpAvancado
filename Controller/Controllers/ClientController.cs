using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    public void registerClient( ClientDTO cliete){
        
    }
    [HttpGet]
    [Route("get")]
    public int getInformations(int ClientID){
        return 3;
    }
}