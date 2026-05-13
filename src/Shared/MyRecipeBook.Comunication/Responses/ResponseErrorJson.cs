namespace MyRecipeBook.Comunication.Responses
{
    public class ResponseErrorJson
    {
        IList<string> Errors { get; set; }

        public ResponseErrorJson(IList<string> errors) => Errors = errors;

        public ResponseErrorJson(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }
    }
}
