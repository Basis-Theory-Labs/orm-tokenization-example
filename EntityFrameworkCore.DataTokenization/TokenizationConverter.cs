using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCore.DataTokenization;

public class TokenizationConverter<TModel> : ValueConverter<TModel, string>
{
    public TokenizationConverter(Expression<Func<TModel, string>> convertToProviderExpression,
        Expression<Func<string, TModel>> convertFromProviderExpression,
        ConverterMappingHints mappingHints = null) :
        base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
    {
    }
}
