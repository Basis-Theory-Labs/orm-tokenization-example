using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.DataTokenization;

public static class ModelBuilderExtensions
{
    public static ModelBuilder UseTokenization(this ModelBuilder modelBuilder,
        TokenizationProvider tokenizationProvider)
    {
        if (tokenizationProvider == null)
            return modelBuilder;

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var attribute = property.PropertyInfo?.GetCustomAttribute<TokenizedAttribute>(false);
                if (attribute == null) continue;

                if (property.ClrType == typeof(string))
                {
                    property.SetValueConverter(new TokenizationConverter<string>(
                        m => tokenizationProvider.Tokenize(m),
                        s => tokenizationProvider.Detokenize<string>(s)));
                }

                if (property.ClrType == typeof(int))
                {
                    property.SetValueConverter(new TokenizationConverter<int>(
                        m => tokenizationProvider.Tokenize(m),
                        s => tokenizationProvider.Detokenize<int>(s)));
                }
            }
        }

        return modelBuilder;
    }
}
