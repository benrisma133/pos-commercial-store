namespace Repository.Factory
{
    public static class clsDataAccessSettings
    {
        public static string ConnectionString =>
            $"Data Source={DbPath};";

        public static string DbPath =>
            Path.Combine(FileSystem.AppDataDirectory, "Data", "CommercialStorePOS.db");
    }
}