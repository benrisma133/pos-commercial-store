using Microsoft.Data.Sqlite;
using Repository.Factory;
using Repository.Loggers;
using Repository.Models;
using System.Data;

namespace Repository.Repositories
{
    public static class CategoryRepository
    {
        private const string _className = nameof(CategoryRepository);

        // ============================
        // ADD NEW — returns new ID
        // ============================
        public static int AddNew(string name)
        {
            try
            {
                using (SqliteConnection connection = DbHelper.OpenConnection())
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO Categories (Name)
                        VALUES (@Name);
                        SELECT last_insert_rowid();
                    ";
                    command.Parameters.AddWithValue("@Name", name);

                    object? result = command.ExecuteScalar();
                    return result == null || result == DBNull.Value ? -1 : Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                clsLog.LogError(_className, nameof(AddNew), ex);
                throw new Exception("Error in AddNew Category: " + ex.Message);
            }
        }

        // ============================
        // UPDATE
        // ============================
        public static bool Update(int categoryId, string name)
        {
            try
            {
                using (SqliteConnection connection = DbHelper.OpenConnection())
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE Categories
                        SET Name = @Name
                        WHERE CategoryId = @CategoryId
                    ";
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@Name", name);

                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                clsLog.LogError(_className, nameof(Update), ex);
                throw new Exception("Error in Update Category: " + ex.Message);
            }
        }

        // ============================
        // DELETE
        // ============================
        public static bool Delete(int categoryId)
        {
            try
            {
                using (SqliteConnection connection = DbHelper.OpenConnection())
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        DELETE FROM Categories
                        WHERE CategoryId = @CategoryId
                    ";
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                // FK violation — category has products linked to it
                return false;
            }
            catch (Exception ex)
            {
                clsLog.LogError(_className, nameof(Delete), ex);
                return false;
            }
        }

        // ============================
        // GET BY ID
        // ============================
        public static Category? GetByID(int categoryId)
        {
            try
            {
                using (SqliteConnection connection = DbHelper.OpenConnection())
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT CategoryId, Name, CreatedAt
                        FROM Categories
                        WHERE CategoryId = @CategoryId
                    ";
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                Name = reader["Name"].ToString()!,
                                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()!)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.LogError(_className, nameof(GetByID), ex);
                throw new Exception("Error in GetByID Category: " + ex.Message);
            }
        }

        // ============================
        // GET ALL
        // ============================
        public static List<Category> GetAll()
        {
            try
            {
                using (SqliteConnection connection = DbHelper.OpenConnection())
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT CategoryId, Name, CreatedAt
                        FROM Categories
                        ORDER BY Name
                    ";

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        List<Category> list = new List<Category>();

                        while (reader.Read())
                        {
                            list.Add(new Category
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                Name = reader["Name"].ToString()!,
                                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()!)
                            });
                        }

                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.LogError(_className, nameof(GetAll), ex);
                throw new Exception("Error in GetAll Categories: " + ex.Message);
            }
        }
    }
}