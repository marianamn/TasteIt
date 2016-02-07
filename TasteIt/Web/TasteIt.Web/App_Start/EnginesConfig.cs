namespace TasteIt.Web
{
    using System.Web.Mvc;

    public class EnginesConfig
    {
        public static void StartOnlyRazor()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}