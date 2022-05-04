using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{


    [HttpPost]
    [Route("register")]
    public string addProductToWishList([FromBody]WishListDTO wishlist){

        var wishlistModel = Model.WishList.convertDTOToModel(wishlist);

        var clientModel = wishlistModel.getClient();

        foreach(var product in wishlistModel.getProducts()){
            wishlistModel.save(clientModel.getDocument(), product.findId());
        }

        return "new" ;
        // {
        //             response = "salvou no banco"
        //     };
    }   
    public void removeProductToWishList(object request)
    {

    }

}
