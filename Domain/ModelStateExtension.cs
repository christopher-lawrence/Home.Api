using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Home.Api.Domain
{
    public static class ModelStateExtension
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                        .Select(e => e.ErrorMessage).ToArray())
                        .Where(m => m.Value.Any());
            }
            return null;
        }
    }
}
