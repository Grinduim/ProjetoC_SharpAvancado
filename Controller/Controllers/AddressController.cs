using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
namespace Controller.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController
    {

        [HttpPost]
        [Route("register")]
        public object registerAddress([FromBody]AddressDTO address){
            return new {
                response = "rota ok"
            };
        }   

        public void removeAddress(AddressDTO address){
        }

        public void updateAddress(AddressDTO address){
        }
    }
}