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
        public string addProductToStock([FromBody] StocksDTO obj){

            Console.WriteLine(obj.productDTO.bar_code);
            Stocks stocksModel = Model.Stocks.convertDTOToModel(obj);

            var id = stocksModel.save(stocksModel.getStore().getID(), stocksModel.getProduct().getID(), obj.quantity, obj.unit_price); 
            
            return "aaaaa";
            // return new {
            //     Status = "Save",
            //     ID = id
            // };
        }

        public void updateStock(object obj){
            
        }
    }
}