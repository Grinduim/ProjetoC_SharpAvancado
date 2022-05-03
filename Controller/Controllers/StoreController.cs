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
        var owner = Model.Owner.convertDTOToModel(store.owner);
        
        // var ownerOBJ = owner.find(owner.getDocument());

        // var id = storeModel.save(ownerOBJ.id);


   

        return new {
                response = "salvou no banco"
        };
    }
}
