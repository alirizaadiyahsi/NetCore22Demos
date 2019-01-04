using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace NetCore22Demos.Models
{
    public static class CustomApiConventions
    {
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Abc(
            [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            int id,
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            string name)
        { }
    }
}