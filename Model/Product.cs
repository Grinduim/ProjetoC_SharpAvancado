namespace Model;
using DAO;
using DTO;
using Interfaces;
public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
{
    private String name;
    private String bar_code;
    public List<ProductDTO> productDTO = new List<ProductDTO>();



    public static Product convertDTOToModel(ProductDTO obj)
    {
        return new Product();
    }

    public void delete(ProductDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var product = new DAO.Product{
                name = this.name,
                bar_code = this.bar_code,
            };

            context.products.Add(product);

            context.SaveChanges();

            id = product.id;

        }
         return id;
    }

    public void update(ProductDTO obj)
    {

    }

    public ProductDTO findById(int id)
    {

        return new ProductDTO();
    }

    public List<ProductDTO> getAll()
    {        
        return this.productDTO;      
    }

   
    public ProductDTO convertModelToDTO()
    {
        var productDTO = new ProductDTO();

        productDTO.name = this.name;

        productDTO.bar_code = this.bar_code;

        return productDTO;
    }




    public void setName(String name) { this.name = name; }
    public String getName() { return this.name; }


    public void setBarCode(String bar_code) { this.bar_code = bar_code; }
    public String getBarCode() { return this.bar_code; }

    public Boolean validateObject()
    {

        if (this.getName() == null) return false;
        if (this.getBarCode() == null) return false;
        return true;
    }

}

