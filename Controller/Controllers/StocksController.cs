using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [Route("Stocks")]
    public class StocksController: ControllerBase
    {   
        [HttpPost]
        [Route("addproduct")]
        public void addProductToStock([FromBody] object request){
            var stocksMode = new Model.Stocks();
            // stocksMode.save(request.store_id, request.product_id, request.quantity, request.unit_price); 

        }

        public void updateStock(object request){
            
        }
    }
}