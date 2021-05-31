using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BobbinPrinter.Models;

namespace BobbinPrinter.SQL
{
    class SQLYarnmakers
    {

        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLYarnmakers()
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

        public void CreateTableYarnmakers()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS yarnmakers" +
            "(" +
            "yarnmaker_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " yarnmaker_name STRING," +
            " yarnmaker_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void AddYarnmaker(YarnmakersModel yarnmakersModel)
        {

            string sqlCommand = "INSERT INTO yarnmakers" +
            " (yarnmaker_name, yarnmaker_archived)" +
            " values" +
            " (" +
            "'" + yarnmakersModel.YarnmakerName + "', "+ yarnmakersModel.YarnmakerArchived +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void UpdateYarnmaker(YarnmakersModel yarnmakersModel)
        {
                        
            string sqlCommand = "UPDATE yarnmakers" +
                " SET" +
                " yarnmaker_name = " + "'" + yarnmakersModel.YarnmakerName.ToUpper() + "'," +
                " yarnmaker_archived = " + yarnmakersModel.YarnmakerArchived +
                " WHERE yarnmaker_id = " + yarnmakersModel.YarnmakerId;
            ExecuteQuery(sqlCommand);
        }

        public bool IsYarnmakerExist(string yarnmakerName)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM yarnmakers " +
                " WHERE " +
                " yarnmaker_name = " + "'" + yarnmakerName.ToUpper() + "'";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }

            return true;
        }


        public List<YarnmakersModel> GetAllYarnmakers()
        {
            List<YarnmakersModel> result = new List<YarnmakersModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM yarnmakers" +
                " ORDER BY yarnmaker_name ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new YarnmakersModel(Convert.ToInt32(reader["yarnmaker_id"]),
                    reader["yarnmaker_name"].ToString(),
                    Convert.ToBoolean(reader["yarnmaker_archived"])));


            }
            reader.Close();

            return result;

        }

        public IEnumerable<YarnmakersModel> GetAllYarnmakers1()
        {
            List<YarnmakersModel> result = new List<YarnmakersModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM yarnmakers" +
                " ORDER BY yarnmaker_name ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new YarnmakersModel(Convert.ToInt32(reader["yarnmaker_id"]),
                    reader["yarnmaker_name"].ToString(),
                    Convert.ToBoolean(reader["yarnmaker_archived"])));


            }
            reader.Close();

            return result;

        }

    }

    
}
