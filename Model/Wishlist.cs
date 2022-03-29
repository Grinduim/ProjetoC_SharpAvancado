namespace Model;
public class Wishlist
{
    private List<Product> products = new List<Product>();
    Client client;
    
    public void setClient( Client client){
        this.client = client;
    }

    public Client getClient(Client client){
        return this.client;
    }

    public List<Product> getProducts(){
        return products;
    }

    public void addProductToWishList(Product product){ //add list to wishlist

        if(!getProducts().Contains(product)){ // se a lista nao conter o produto na lusta
            this.products.Add(product);// adicionar ela na lista
        }
    }
}
