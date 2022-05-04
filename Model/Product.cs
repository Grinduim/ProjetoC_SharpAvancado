namespace Model;
using DAO;
using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
{
    private String name;
    private String bar_code;



    public static Product convertDTOToModel(ProductDTO obj)
    {
        Console.WriteLine("Entrou em product"); 
        Console.WriteLine(obj.name);
        var product = new Model.Product{
            name = obj.name,
            bar_code = obj.bar_code
        };
        Console.WriteLine("Passou Product");
        Console.WriteLine("passou aq");
        Console.WriteLine("Saiu de product");
        return product;
    }

    public void delete()
    {
        using (var context = new DAOContext())
        {

            var product = context.products.FirstOrDefault(c => c.bar_code == this.bar_code);

            context.products.Remove(product);

            context.SaveChanges();
        }
    }
    public int save()
    {
        var id = 0;

        using (var context = new DAOContext())
        {
            var product = context.products
                .FirstOrDefault(c => c.bar_code == this.bar_code);
            if (product != null)
            {
                return -1;
            }
            product = new DAO.Product
            {
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
        using(var context = new DAOContext()){
            var product = context.products.FirstOrDefault(i=> i.bar_code == obj.bar_code);

            if( product != null){
                context.Entry(product).State = EntityState.Modified;
                product.name = obj.name;
            }
            context.SaveChanges();
        }
    }

    public ProductDTO findById(int id)
    {
        return new ProductDTO();
    }

    public List<ProductDTO> getAll()
    {
        return new List<ProductDTO>();
    }

    public int getID(){
        using(var context = new DAOContext()){
            var ID  = context.products.FirstOrDefault(p => p.bar_code == this.bar_code).id;
            return ID;
        }
    }

    public static List<ProductDTO> getAllStatic()
    {
        using (var context = new DAOContext())
        {
            var productsDAO = context.products;


            var productsDTO = new List<ProductDTO>();
            
            foreach (var item in productsDAO)
            {
                var TransitionDAO = new DTO.ProductDTO();
                TransitionDAO.bar_code = item.bar_code;
                TransitionDAO.name = item.name;
                productsDTO.Add(TransitionDAO);
            }
            return productsDTO;
        }
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