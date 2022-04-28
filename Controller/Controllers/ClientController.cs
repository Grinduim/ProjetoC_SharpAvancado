using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[Client]")]

public class ClientController : ControllerBase
{
    public void registerClient( ClientDTO cliete){
        
    }

    public Client getInformations(){
        return new Client();
    }
}