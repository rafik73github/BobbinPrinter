using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BobbinPrinter.Models;

namespace BobbinPrinter.SQL
{
    class SQLYarntypes
    {

        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLYarntypes()
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

        public void CreateTableYarntypes()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS yarntypes" +
            "(" +
            "yarntype_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " yarntype_name STRING," +
            "yarntype_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void AddYarntype(YarntypesModel yarntypesModel)
        {

            string sqlCommand = "INSERT INTO yarntypes" +
            " (yarntype_name, yarntype_archived)" +
            " values" +
            " (" +
            "'" + yarntypesModel.YarntypeName + "', " + yarntypesModel.YarntypeArchived +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void UpdateYarntype(YarntypesModel yarntypesModel)
        {

            string sqlCommand = "UPDATE yarntypes" +
                " SET" +
                " yarntype_name = " + "'" + yarntypesModel.YarntypeName.ToUpper() + "'," +
                " yarntype_archived = " + yarntypesModel.YarntypeArchived +
                " WHERE yarntype_id = " + yarntypesModel.YarntypeId;
            ExecuteQuery(sqlCommand);
        }

        public bool IsYarntypeExist(string yarntypeName)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM yarntypes " +
                " WHERE " +
                " yarntype_name = " + "'" + yarntypeName.ToUpper() + "'";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }

            return true;
        }


        public List<YarntypesModel> GetAllYarntypes()
        {
            List<YarntypesModel> result = new List<YarntypesModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM yarntypes" +
                " ORDER BY yarntype_name ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new YarntypesModel(Convert.ToInt32(reader["yarntype_id"]),
                    reader["yarntype_name"].ToString(),
                    Convert.ToBoolean(reader["yarntype_archived"])));


            }
            reader.Close();

            return result;

        }

    }
}
