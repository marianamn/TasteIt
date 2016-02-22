namespace TasteIt.Web.Infrastructure
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
