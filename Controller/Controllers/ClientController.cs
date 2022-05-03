using DTO;
using DAO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody]ClientDTO client){
        var clientModel = Model.Client.convertDTOToModel(client);
        int id = clientModel.save();

        return new {
                response = "salvou no banco"
        };
    }   
    
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document){

        var client = Model.Client.FindByDocument(document);
    
        return client;
    }
}


