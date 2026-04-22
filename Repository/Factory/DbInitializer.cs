namespace Repository.Factory
{
    public static class DbInitializer
    {
        public static async Task InitAsync()
        {
            // 1. Make sure the Data folder exists
            string dataFolder = Path.Combine(FileSystem.AppDataDirectory, "Data");
            Directory.CreateDirectory(dataFolder);

            // 2. If DB already exists skip everything
            string dbPath = clsDataAccessSettings.DbPath;
            if (File.Exists(dbPath)) return;

            // 3. Copy the DB file from app bundle to device storage
            using Stream source = await FileSystem.OpenAppPackageFileAsync("CommercialStorePOS.db");
            using FileStream dest = File.Create(dbPath);
            await source.CopyToAsync(dest);
        }
    }
}