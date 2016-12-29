using System;
using System.Reflection;

namespace Dhgms.JobHelper.ApiWebSite.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}