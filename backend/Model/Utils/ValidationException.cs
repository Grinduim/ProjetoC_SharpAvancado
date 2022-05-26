namespace Model.Utils
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();

        public void Add(string field, string error)
            => this.Errors.Add(field, error);
    }
}