using DTO;
using Model;
using System;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;


[ApiController]
[Route("[controller]")]

public class StoreController : ControllerBase
{

// [HttpGet]
// [Route("get/{document}")]
// public ClientDTO getAllStore(String document){

//     var client = Model.Client.find(document);

//     return client;
// }

    [HttpPost]
    [Route("register")]
    public object registerStore([FromBody]StoreDTO store){

        var storeModel = Model.Store.convertDTOToModel(store);

        var id = storeModel.save(Model.Store.GetOwnerId(storeModel.getOwner()));

        return new {
                response = "salvou no banco"
        };
    }
}
