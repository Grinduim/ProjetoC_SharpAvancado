using DTO;
using Model;
using System;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;


[ApiController]
[Route("[controller]")]

public class StoreController : ControllerBase
{

    [HttpGet]
    [Route("get/{CNPJ}")]
    public object getStore(String CNPJ){

        var store = Model.Store.find(CNPJ);

        return store;
    }



    [HttpGet]
    [Route("get/all")]
    public List<object> getAllStore(){

        var allStore = Model.Store.findAll();

        return allStore;
    }




    [HttpPost]
    [Route("register")]
    public object registerStore([FromBody]StoreDTO store){

        var storeModel = Model.Store.convertDTOToModel(store);

        storeModel.save(Model.Store.GetOwnerId(Model.Owner.convertDTOToModel(store.owner)));

        return new {
                response = "salvou no banco"
        };
    }
}
