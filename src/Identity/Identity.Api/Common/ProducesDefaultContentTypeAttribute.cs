using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Common;

public class ProducesDefaultContentTypeAttribute : ProducesAttribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public ProducesDefaultContentTypeAttribute(Type type) : base(type)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="additionalContentTypes"></param>
    public ProducesDefaultContentTypeAttribute(params string[] additionalContentTypes)
        : base("application/json", additionalContentTypes)
    {
    }
}