using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
using Microsoft.AspNetCore.Cors;
using System.Linq;
namespace Controller.Controllers;

[ApiController]
[Route("product")]

public class ProductController : ControllerBase
{


    [HttpPost]
    [Route("create")]
    public object createProduct([FromBody] ProductDTO product){
        var productModel = Model.Product.convertDTOToModel(product);

        int id =  productModel.save();
        if(id == -1){
            return new {
                response = "Registro já existe"};
        }
        return new {response = id};
    }

    [HttpDelete]
    [Route("delete")]
    public object  deleteProduct([FromBody]ProductDTO product){
        var productModel =  Model.Product.convertDTOToModel(product);
        productModel.delete();

        return new{
            status = "ok",
            mensagem = "excluido com sucesso"
        };
    }

    [HttpPut]
    [Route("update")]
    public object updateProduct([FromBody] ProductDTO product){
        var productModel =  Model.Product.convertDTOToModel(product); 
        
        productModel.update(product);
        return new { status = "sucess"};
    }

    [HttpGet]
    [Route("getall")]
    public IActionResult  allProducts(){
        var response = Model.Product.getAllStatic();
       var  retorno = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return retorno;
    }

    [HttpGet]
    [Route("getproduct/{id}")]
    public IActionResult getProduct(int id){
        var response = Model.Product.getProductById(id);
        
        var  retorno = new ObjectResult(response);
         Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return retorno;
    }
}