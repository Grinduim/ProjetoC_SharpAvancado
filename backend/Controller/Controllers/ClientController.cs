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
        catch (Exception e)
        {
            return new
            {
                response = new
                {
                    e.Message
                }
            };
        }
        return new
        {
            response = "Sucess"
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


