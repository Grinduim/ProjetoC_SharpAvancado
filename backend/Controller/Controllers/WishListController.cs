using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{


    [HttpPost]
    [Route("register")]
    public object addProductToWishList([FromBody]WishListDTO wishlist){

        var wishlistModel = Model.WishList.convertDTOToModel(wishlist);

        var clientModel = wishlistModel.getClient();

        foreach(var product in wishlistModel.getProducts()){
            wishlistModel.save(clientModel.getDocument(), product.findId());
        }

        return new
        {
                response = "salvou no banco"
        };
    }   



    [HttpDelete]
    [Route("delete")]
    public object removeProductToWishList([FromBody]WishListDTO wishlist)
    {
         var wishlistModel =  Model.WishList.convertDTOToModel(wishlist);

         
        wishlistModel.deleteProduct();



        return new
        {
                response = "salvou no banco"
        };
    }

}
