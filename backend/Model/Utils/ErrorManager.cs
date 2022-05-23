namespace Model.Utils;

public enum Errors
{
    EmailAlreadyExists,
    DocumetnAlreadyExists
}
public class Error
{
    private Dictionary<Errors, string> dict = new Dictionary<Errors, string>();
    public string this[Errors code] => dict[code];

    private Error()
    {
        dict[Errors.EmailAlreadyExists] = "O Email já está cadastrado no sistema.";
        dict[Errors.DocumetnAlreadyExists] = "O Documento já está cadastrado no sistema.";
    }
    private static Error crr = new Error();
    public static Error Manager => crr;
}