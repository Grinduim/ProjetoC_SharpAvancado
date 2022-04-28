using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody]ClientDTO client){
        var clientModel = Model.Client.convertDTOToModel(client);
        int id = clientModel.save();

        return new {
                response = "salvou on banco"
        };
    }   



    [HttpGet]
    [Route("get")]
    public int getInformations(int ClientID){
        return 3;
    }
}