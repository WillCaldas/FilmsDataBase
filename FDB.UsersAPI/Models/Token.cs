namespace FDB.UsersAPI.Models
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            Value = value;
        }

    }
}
