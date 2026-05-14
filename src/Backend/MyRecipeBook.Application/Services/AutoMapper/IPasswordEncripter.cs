namespace MyRecipeBook.Application.Services.AutoMapper
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
    }
}
