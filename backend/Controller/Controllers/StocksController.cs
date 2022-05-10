using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controller.Controllers
{
    
    [ApiController]
    [Route("Stocks")]
    public class StocksController: ControllerBase
    {   
        [HttpPost]
        [Route("addproduct")]
        public object addProductToStock([FromBody] StocksDTO obj){

            Stocks stocksModel = Model.Stocks.convertDTOToModel(obj);
            var id = stocksModel.save(stocksModel.getStore().getID(), stocksModel.getProduct().getID(), obj.quantity, obj.unit_price); 
            
            return new {
                Status = "Save",
                ID = id
            };
        }

        [HttpPut]
        [Route("update")]
        public void updateStock([FromBody] StocksDTO obj){
            
            Stocks stocksModel = Model.Stocks.convertDTOToModel(obj);
            
            stocksModel.update(obj);

        }
    }
}