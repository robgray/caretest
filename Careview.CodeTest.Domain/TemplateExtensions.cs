namespace Careview.CodeTest.Domain;

public static class TemplatingExtensions
{
    public static string MergeTemplateWith<T>(this string template, T client, bool removeExtraWhitespace = false)
    {
        string output = template;
        
        var properties = typeof(T).GetProperties();
        foreach (var prop in properties)
        {
            output = output.Replace("{{" + prop.Name + "}}", (prop.GetValue(client) as string) ?? "");
        }

        return removeExtraWhitespace ? RemoveExtraWhitespace(output) : output;

        string RemoveExtraWhitespace(string aString)
        {
            while (output.Contains("  "))
            {
                output = output.Replace("  ", " ");
            }

            return output.Trim();
        }
    }
}