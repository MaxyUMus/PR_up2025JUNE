using MaterialSkin;
using Npgsql;
using System.Text.RegularExpressions;

namespace maxim_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthForm());
        }
    }

    internal static class Constants
    {
        internal static string ConnectionString = "Host=localhost;Port=5433;Database=not_movable_agency;Username=postgres;Password=11111111";
        internal static Color PrimaryBackgroundColor = ColorTranslator.FromHtml("#FFFFFF");
        internal static Color SecondaryBackgroundColor = ColorTranslator.FromHtml("#8EADC4");
        internal static Color AccentColor = ColorTranslator.FromHtml("#420502");
        internal static NpgsqlConnection Connection = new NpgsqlConnection(ConnectionString);
    }

    internal static class Methods
    {
        internal static TextShade GetContrastTextShade(Color backgroundColor)
        {
            double brightness = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return brightness > 0.5 ? TextShade.BLACK : TextShade.WHITE;
        }

        internal static Color GetContrastTextColor(Color backgroundColor)
        {
            double brightness = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return brightness > 0.5 ? Color.Black : Color.White;
        }

        internal static bool ValidatePhoneNumber(string phone)
        {
            string pattern = @"^\+7\s?\(?\d{3}\)?\s?\d{3}-?\d{2}-?\d{2}$";
            return Regex.IsMatch(phone, pattern);
        }

        internal static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        internal static List<string> GetEnumValues(string enumTypeName)
        {
            Constants.Connection.Open();
            var values = new List<string>();

            string sql = @"
                    SELECT e.enumlabel 
                    FROM pg_enum e
                    JOIN pg_type t ON e.enumtypid = t.oid
                    WHERE t.typname = @enumTypeName
                    ORDER BY e.enumsortorder";

            using (var cmd = new NpgsqlCommand(sql, Constants.Connection))
            {
                cmd.Parameters.AddWithValue("@enumTypeName", enumTypeName);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        values.Add(reader.GetString(0));
                    }
                }
            }
            Constants.Connection.Close();
            return values;
        }

        internal static List<string> GetDatabaseTables()
        {
            List<string> ret = new List<string>();
            Constants.Connection.Open();
            string query = @"
                SELECT table_name 
                FROM information_schema.tables 
                WHERE table_schema = 'public' 
                  AND table_type = 'BASE TABLE'
                  AND NOT table_name = 'users'
                  AND NOT table_name = 'objects';
            ";


            using (var cmd = new NpgsqlCommand(query, Constants.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ret.Add(reader.GetString(0));
                    }
                }
            }
            Constants.Connection.Close();
            return ret;
        }

        internal static bool TableExists(string tableName)
        {
            Constants.Connection.Open();
            bool ret_value = false;
            string query = $"SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = '{tableName}')";
            using (var cmd = new NpgsqlCommand(query, Constants.Connection)) 
            {
                ret_value = (bool)cmd.ExecuteScalar();
            }
            Constants.Connection.Close();
            return ret_value;
        }

        internal static List<ColumnInfo> GetTableColumnsInfo(string tableName)
        {
            Constants.Connection.Open();
            var columnsInfo = new List<ColumnInfo>();

            string query = @"
        SELECT 
            column_name, 
            udt_name,
            data_type
        FROM 
            information_schema.columns 
        WHERE 
            table_name = @tableName;
        ";

            using (var cmd = new NpgsqlCommand(query, Constants.Connection))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        string udtName = reader.GetString(1);
                        string dataType = reader.GetString(2);
                        bool isEnum = udtName.StartsWith("_") || dataType == "USER-DEFINED";

                        columnsInfo.Add(new ColumnInfo
                        {
                            ColumnName = columnName,
                            DataType = dataType,
                            UdtName = udtName,
                            IsEnum = isEnum,
                            EnumTypeName = isEnum ? udtName.TrimStart('_') : null
                        });
                    }
                }
            }
            foreach (var column in columnsInfo.Where(c => c.IsEnum))
            {
                string getEnumTypeQuery = @"
            SELECT t.typname 
            FROM pg_type t 
            JOIN pg_enum e ON t.oid = e.enumtypid 
            WHERE t.typname LIKE @udtName 
            LIMIT 1;
        ";

                using (var cmd = new NpgsqlCommand(getEnumTypeQuery, Constants.Connection))
                {
                    cmd.Parameters.AddWithValue("@udtName", column.UdtName.TrimStart('_') + "%");
                    var enumTypeName = cmd.ExecuteScalar()?.ToString();
                    if (!string.IsNullOrEmpty(enumTypeName))
                    {
                        column.EnumTypeName = enumTypeName;
                    }
                }
            }
            Constants.Connection.Close();
            return columnsInfo;
        }
    }
    internal class ColumnInfo
    {
        internal required string ColumnName { get; set; }
        internal required string DataType { get; set; }
        internal required string UdtName { get; set; }
        internal bool IsEnum { get; set; }
        internal required string EnumTypeName { get; set; }
    }
}