using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody] ClientDTO client)
    {
        var clientModel = Model.Client.convertDTOToModel(client);
        try
        {
            int id = clientModel.save();
        }
        catch
        {
            return new
            {
                response = "erro"
            };
        }
        return new
        {
            response = "salvou"
        };



    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document)
    {

        var client = Model.Client.find(document);

        return client;
    }
}


