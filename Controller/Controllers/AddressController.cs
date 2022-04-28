using DAO;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {

        [HttpPost]
        [Route("register")]
        public object registerAddress([FromBody]AddressDTO address){
            var addressModel = Model.Address.convertDTOToModel(address);
            int id = addressModel.save();
            return new {
                street = address.street,
                city = address.city,
                state = address.state,
                country = address.country,
                postal_code = address.postal_code,
                id = id
            };
            


        }   

        public void removeAddress(AddressDTO address){
        }

        public void updateAddress(AddressDTO address){
        }
    }
}