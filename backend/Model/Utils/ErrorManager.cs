namespace Model.Utils;

public enum Errors
{
    EmailAlreadyExists,
    DocumetnAlreadyExists,
    LoginAlreadyExists
}
public class Error
{
    private static Dictionary<Errors, string> dict {get;set;} = new Dictionary<Errors, string>();
    // public string this[Errors code] => dict[code];

    private Error()
    {
        dict[Errors.EmailAlreadyExists] = "O Email já está cadastrado no sistema.";
        dict[Errors.DocumetnAlreadyExists] = "O Documento já está cadastrado no sistema.";
        dict[Errors.LoginAlreadyExists] = "O Login já está cadastrado no sistema.";
    }
    private static Error crr = new Error();
    public static Error Manager => crr;

    public static string GetMessage(Errors error){
        return dict[error];
    }
}