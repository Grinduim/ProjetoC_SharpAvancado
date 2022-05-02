using DTO;
using Microsoft.AspNetCore.Mvc;


namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController
{

<<<<<<< HEAD
        [HttpPost]
        [Route("register")]
        public object registerAddress([FromBody] AddressDTO address)
        {
            var addressModel = Model.Address.convertDTOToModel(address);
            int id = addressModel.save();
            return new
            {
                response = "salvou on banco"
            };
        }

        [HttpDelete]
        [Route("Delete")]
        public void removeAddress([FromBody] AddressDTO address)
        {
            var addressModel = Model.Address.convertDTOToModel(address);
            addressModel.delete();
            return new {
                status = "ok",
                mensagem = "Excluido com sucesso"
            };

            

        }

        public void updateAddress(AddressDTO address)
        {
        }
    }
}
=======
[HttpPost]
[Route("register")]
public object registerAddress([FromBody]AddressDTO address){
    var addressModel = Model.Address.convertDTOToModel(address);
    int id = addressModel.save();
    return new {
        response = "salvou on banco"
    };
}   

public void removeAddress(AddressDTO address){
}

public void updateAddress(AddressDTO address){
}
}
>>>>>>> 5156b67b7d0b0b21ca26158ca55d480a163f55f6
