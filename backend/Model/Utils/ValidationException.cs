namespace Model.Utils
{
    public class ValidationException : Exception
    {
        public Dictionary<string, Errors> Errors { get; private set; } = new Dictionary<string, Errors>();

        public void Add(string field, Errors error)
            => this.Errors.Add(field, error);
    }
}