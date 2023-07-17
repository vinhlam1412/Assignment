namespace HQSOFT.Configuration.HQTasks
{
    public static class HQTaskConsts
    {
        private const string DefaultSorting = "{0}Subject asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "HQTask." : string.Empty);
        }

    }
}