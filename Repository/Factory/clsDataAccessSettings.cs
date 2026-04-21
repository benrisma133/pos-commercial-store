namespace Repository.Factory
{
    public static class clsDataAccessSettings
    {
        public static string ConnectionString =
            $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "CommercialStorePOS.db")};";
    }
}