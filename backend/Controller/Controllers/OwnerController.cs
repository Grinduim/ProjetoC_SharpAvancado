using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner([FromBody]OwnerDTO owner){
        var ownerModel = Model.Owner.convertDTOToModel(owner);
        int id = ownerModel.save();

        return new {
                response = "salvou no banco"
        };
    }   



    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document){

        var owner = Model.Owner.FindByDocument(document);
    
        return owner;
    }
}
