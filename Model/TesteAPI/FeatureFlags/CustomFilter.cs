using Microsoft.FeatureManagement;

[FilterAlias(nameof(CustomFilter))]
public class CustomFilter : IFeatureFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CustomFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var userLanguage = _httpContextAccessor.HttpContext.Request.Headers["EnabledFor"].ToString();
        var settings = context.Parameters.Get<CustomFilter>();
        return Task.FromResult(settings.Equals(userLanguage));
    }
}