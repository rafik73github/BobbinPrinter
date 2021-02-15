using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class SQLYarnsizes
    {

        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLYarnsizes()
        {
            sqlConnection = new SQLiteConnection(DatabasePatch.GetDatabasePatch());
            sqlConnection.Open();
            command = sqlConnection.CreateCommand();
        }

        public void ExecuteQuery(string sqlCommand)
        {

            SQLiteCommand triggerCommand = sqlConnection.CreateCommand();
            triggerCommand.CommandText = sqlCommand;
            triggerCommand.ExecuteNonQuery();
        }

        public void CreateTableYarnsizes()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS yarnsizes" +
            "(" +
            "yarnsize_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " yarnsize_name STRING," +
            "yarnsize_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void AddYarnsize(YarnsizesModel yarnsizesModel)
        {

            string sqlCommand = "INSERT INTO yarnsizes" +
            " (yarnsize_name, yarnsize_archived)" +
            " values" +
            " (" +
            "'" + yarnsizesModel.YarnsizeName + "', " + yarnsizesModel.YarnsizeArchived +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void UpdateYarnsize(YarnsizesModel yarnsizesModel)
        {

            string sqlCommand = "UPDATE yarnsizes" +
                " SET" +
                " yarnsize_name = " + "'" + yarnsizesModel.YarnsizeName.ToUpper() + "'," +
                " yarnsize_archived = " + yarnsizesModel.YarnsizeArchived +
                " WHERE yarnsize_id = " + yarnsizesModel.YarnsizeId;
            ExecuteQuery(sqlCommand);
        }

        public bool IsYarnsizeExist(string yarnsizeName)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM yarnsizes " +
                " WHERE " +
                " yarnsize_name = " + "'" + yarnsizeName.ToUpper() + "'";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }

            return true;
        }


        public List<YarnsizesModel> GetAllYarnsizes()
        {
            List<YarnsizesModel> result = new List<YarnsizesModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM yarnsizes" +
                " ORDER BY yarnsize_name ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new YarnsizesModel(Convert.ToInt32(reader["yarnsize_id"]),
                    reader["yarnsize_name"].ToString(),
                    Convert.ToBoolean(reader["yarnsize_archived"])));


            }
            reader.Close();

            return result;

        }

    }
}
