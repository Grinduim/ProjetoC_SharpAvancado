namespace Model;
public class Person
{
    protected String name= "";
    protected int age;
    protected String document= "";
    protected String email= "";
    protected String phone= "";
    protected String login= "";
    protected Address address;

    public Person(Address address)
    {
        this.address= address;
    }

    public void setName(String name)
    {
        this.name= name;
    }
    public void setAge(int age)
    {
        this.age= age;
    }
    public void setDocument(string document)
    {
        this.document= document;
    }
    public void setEmail(String email)
    {
        this.email= email;
    }
    public void setPhone(String phone)
    {
        this.phone= phone;
    }
    public void setLogin(String email)
    {
        this.email = email;
    }
    public void setAddress(Address address)
    {
        this.address = address;
    }
    public String getName()
    {
        return this.name;
    }
    public int getAge()
    {
        return this.age;
    }
    public String getDocument()
    {
        return this.document;
    }
    public String getEmail()
    {
        return this.email;
    }
    public String getPhone()
    {
        return this.phone;
    }

    public String getLogin()
    {
        return this.login;
    }

    public Address getAddress()
    {
        return this.address;
    }
}
