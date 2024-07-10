using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(c => c.Value!.Errors)
            .Select(c => c.ErrorMessage)
            .ToList();
    }
}