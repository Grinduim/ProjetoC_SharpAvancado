using DTO;
using Microsoft.AspNetCore.Mvc;


namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController: ControllerBase
{

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
    public object removeAddress([FromBody] AddressDTO address)
    {
        var addressModel = Model.Address.convertDTOToModel(address);
        addressModel.delete();
        return new
        {
            status = "ok",
            mensagem = "Excluido com sucesso"
        };
    }

    public void updateAddress(AddressDTO address)
    {
        
        
    }
}
