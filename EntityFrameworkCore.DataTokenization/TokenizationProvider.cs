using BasisTheory.net.Tokens;
using BasisTheory.net.Tokens.Entities;

namespace EntityFrameworkCore.DataTokenization;

public class TokenizationProvider
{
    private readonly TokenClient _tokenClient;

    public TokenizationProvider(string apiKey) =>
        _tokenClient = new TokenClient(apiKey);

    public string Tokenize<TModel>(TModel dataToTokenize)
    {
        var token = _tokenClient.Create(new Token
        {
            Type = "token",
            Data = dataToTokenize
        });

        return token.Id.ToString();
    }

    public TModel Detokenize<TModel>(string dataToDetokenize)
    {
        var token = _tokenClient.GetById(dataToDetokenize);

        return (TModel) token.Data;
    }
}
