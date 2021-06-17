using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BobbinPrinter.Models;

namespace BobbinPrinter.SQL
{
    class SQLYarns
    {
        readonly SQLiteConnection sqlConnection;
        readonly SQLiteCommand command;

        public SQLYarns()
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

        public void CreateTableYarns()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS yarns" +
            "(" +
            "yarn_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " yarn_maker INTEGER," +
            " yarn_type INTEGER," +
            " yarn_size INTEGER," +
            " yarn_color STRING," +
            " yarn_package_count INTEGER," +
            "yarn_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void AddYarn(YarnsModel yarnsModel)
        {

            string sqlCommand = "INSERT INTO yarns" +
            " (yarn_maker, yarn_type, yarn_size, yarn_color, yarn_package_count, yarn_archived)" +
            " values" +
            " (" +
            yarnsModel.YarnMaker + ", " +
            yarnsModel.YarnType + ", " + 
            yarnsModel.YarnSize + ", " +
            "'" + yarnsModel.YarnColor + "', " +
            yarnsModel.YarnBobbinInPackageCount + ", " +
            yarnsModel.YarnArchived +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void UpdateYarn(YarnsModel yarnsModel)
        {

            string sqlCommand = "UPDATE yarns" +
                " SET " +
                "yarn_maker = " + yarnsModel.YarnMaker + ", " +
                "yarn_type = " + yarnsModel.YarnType + "' " + 
                "yarn_size = " + yarnsModel.YarnSize + ", " +
                "yarn_color = " + "'" + yarnsModel.YarnColor.ToUpper() + "'," +
                "yarn_package_count = " + yarnsModel.YarnBobbinInPackageCount + ", " +
                " yarn_archived = " + yarnsModel.YarnArchived +
                " WHERE yarn_id = " + yarnsModel.YarnId;
            ExecuteQuery(sqlCommand);
        }

        public bool IsYarnExist(int yarnMaker, int yarnType, int yarnSize, string yarnColor, int yarnPackageCount)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM yarns " +
                " WHERE " +
                " yarn_maker = " + yarnMaker +
                " AND yarn_type = " + yarnType +
                " AND yarn_size = " + yarnSize + 
                " AND yarn_color = " + "'" + yarnColor + "'" +
                " AND yarn_package_count = " + yarnPackageCount;

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }

            return true;
        }

        public List<YarnsModel> GetAllYarns()
        {
            List<YarnsModel> result = new List<YarnsModel>();

            command.CommandText = "SELECT" +
                " a.yarn_id AS a_yarn_id," +
                " a.yarn_maker AS a_yarn_maker," +
                " b.yarnmaker_name AS b_yarnmaker_name," +
                " a.yarn_type AS a_yarn_type," +
                " c.yarntype_name AS c_yarntype_name," +
                " a.yarn_size AS a_yarn_size," +
                " d.yarnsize_name AS d_yarnsize_name," +
                " a.yarn_color AS a_yarn_color," +
                " a.yarn_package_count AS a_yarn_package_count," +
                " a.yarn_archived AS a_yarn_archived" +
                " FROM yarns AS a" +
                " LEFT JOIN yarnmakers AS b ON a.yarn_maker = b.yarnmaker_id" +
                " LEFT JOIN yarntypes AS c ON a.yarn_type = c.yarntype_id" +
                " LEFT JOIN yarnsizes AS d ON a.yarn_size = d.yarnsize_id" +
                " ORDER BY b.yarnmaker_name ASC, a.yarn_type ASC, a.yarn_color ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new YarnsModel(Convert.ToInt32(reader["a_yarn_id"]),
                    Convert.ToInt32(reader["a_yarn_maker"]),
                    reader["b_yarnmaker_name"].ToString(),
                    Convert.ToInt32(reader["a_yarn_type"]),
                    reader["c_yarntype_name"].ToString(),
                    Convert.ToInt32(reader["a_yarn_size"]),
                    reader["d_yarnsize_name"].ToString(),
                    reader["a_yarn_color"].ToString(),
                    Convert.ToInt32(reader["a_yarn_package_count"]),
                    Convert.ToBoolean(reader["a_yarn_archived"])));


            }
            reader.Close();

            return result;

        }

    }
}
