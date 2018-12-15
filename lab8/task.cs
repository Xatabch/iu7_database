using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lab9.NET
{
    class Tasks
    {
        private readonly string connectionString = @"server = localhost; database = testdb; user id = sa; password = 0765842953VaNy";

        static void Main(string[] args)
        {
            Tasks solution = new Tasks();

            // Запросы с присоединенными объектами
            // solution.firstQuerySelection_connect();
            // solution.secondQueryInsertAndDelete_connect();
            // solution.thirdQueryScalar_connect();
            // solution.fourthProcedureSelectSommelierWines_connect();
            solution.fifthQueryDatabaseOptions_connect();

            // Запросы с отсоединенными объектами
            //solution.fristQueryDataSetFromTable_disconnect();
            //solution.secondQueryFilterTable_disconnect();
            //solution.thirdQueryInsert_disconnect();
            //solution.fourthQueryDelete_disconnect();
            //solution.fifthQueryXml_disconnect();
        }

        // Вина у которых страна Италия
        public void firstQuerySelection_connect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 1, "[Connected] DataReader for query.");

            string queryString = @"select Title from WINE where Country_id = 2";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand dataQueryCommand = new SqlCommand(queryString, connection);
            Console.WriteLine("Sql command \"{0}\" has been created.", queryString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");
                SqlDataReader dataReader = dataQueryCommand.ExecuteReader();

                Console.WriteLine("Wine from Italy: ");
                while (dataReader.Read())
                {
                    Console.WriteLine("\t{0}", dataReader.GetValue(0));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Вставка в таблицу COUNTRY
        // Удаление из таблицы COUNTRY
        public void secondQueryInsertAndDelete_connect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 2, "[Connected] SqlCommand (Insert, Delete).");

            
            string insertQueryString = @"insert into COUNTRY (ID, Country) values (@ID, @Country)";
            string deleteQueryString = @"delete from COUNTRY where ID = @ID";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand insertQueryCommand = new SqlCommand(insertQueryString, connection);
            SqlCommand deleteQueryCommand = new SqlCommand(deleteQueryString, connection);

            insertQueryCommand.Parameters.Add("@ID", SqlDbType.Int);
            insertQueryCommand.Parameters.Add("@Country", SqlDbType.VarChar, 20);
            deleteQueryCommand.Parameters.Add("@ID", SqlDbType.Int);

            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.\n");
                Console.WriteLine("Inserting a new Country. Input: ");
                Console.Write("- ID = ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("- Country = ");
                string Name = Console.ReadLine();
                Console.Write("- Delete ID = ");
                int ID_d = Convert.ToInt32(Console.ReadLine());

                insertQueryCommand.Parameters["@ID"].Value = ID;
                insertQueryCommand.Parameters["@Country"].Value = Name;
                deleteQueryCommand.Parameters["@ID"].Value = ID_d;

                Console.WriteLine("\nInsert command: {0}", insertQueryCommand.CommandText);
                insertQueryCommand.ExecuteNonQuery();
                
                Console.WriteLine("Delete command: {0}", deleteQueryCommand.CommandText);
                deleteQueryCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Bad input! " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Скалярный запрос
        public void thirdQueryScalar_connect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 3, "[Connected] Scalar query.");

            string queryString = @"select count(*) from WINE";
            SqlConnection connection = new SqlConnection(connectionString);
            
            SqlCommand scalarQueryCommand = new SqlCommand(queryString, connection);
            Console.WriteLine("Sql command \"{0}\" has been created.", queryString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");
                Console.WriteLine("The count of Wines is {0}", scalarQueryCommand.ExecuteScalar());
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Запрос в базу, чтобы по всем сомелье выдавались их вина
        public void fourthProcedureSelectSommelierWines_connect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 5, "SommelierWines.");

            string queryString = @"select Title from WINE join (select WINE_ID, TasterName from WINE_SOMMELIER join SOMMELIER ON WINE_SOMMELIER.SOMMELIER_ID = SOMMELIER.ID ) AS WS ON WINE.ID = WS.WINE_ID where TasterName=@TasterName";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand dataQueryCommand = new SqlCommand(queryString, connection);
            dataQueryCommand.Parameters.Add("@TasterName", SqlDbType.VarChar, 40);

            Console.WriteLine("Sql command \"{0}\" has been created.", queryString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");
                Console.WriteLine("Select wines by sommelier. Input: ");
                Console.Write("- Sommelier name = ");
                string TasterName = Console.ReadLine();

                dataQueryCommand.Parameters["@TasterName"].Value = TasterName;

                SqlDataReader dataReader = dataQueryCommand.ExecuteReader();

                Console.WriteLine("Wines that Sommelier taste: ");
                while (dataReader.Read())
                {
                    Console.WriteLine("\t{0}", dataReader.GetValue(0));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Параметры подключения
        public void fifthQueryDatabaseOptions_connect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 1, "[Connected] Shows connection info.");

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");
                Console.WriteLine("Connection properties:");
                Console.WriteLine("\tConnection string: {0}", connection.ConnectionString);
                Console.WriteLine("\tDatabase:          {0}", connection.Database);
                Console.WriteLine("\tData Source:       {0}", connection.DataSource);
                Console.WriteLine("\tServer version:    {0}", connection.ServerVersion);
                Console.WriteLine("\tConnection state:  {0}", connection.State);
                Console.WriteLine("\tWorkstation id:    {0}", connection.WorkstationId);
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the connection creating. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }








        // Тот же что и в первом только дисконнект
        public void fristQueryDataSetFromTable_disconnect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 1, "[Disconnected] DataSet from the table.");

            string query = @"select Title from WINE where Country_id = 1";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Italy");
                DataTable table = dataSet.Tables["Italy"];

                Console.WriteLine("Wine from Italy:");
                foreach (DataRow row in table.Rows)
                {
                    Console.Write("{0} \n", row["Title"]);
                }
                Console.WriteLine();
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql query execution. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Фильтрует описания по нужному слову
        public void secondQueryFilterTable_disconnect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 2, "[Disconnected] Filter.");

            string query = @"select * from WINE join DESCRIPTION ON WINE.Description_id = DESCRIPTION.ID";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "WINE");
                DataTableCollection tables = dataSet.Tables;

                Console.Write("Input word what must exists description: ");
                string word = Console.ReadLine();
                Console.WriteLine();

                string filter = "Description like '%" + word + "%'";
                Console.WriteLine("Description what exist word like \"" + word + "\":\n------------------------\n");
                foreach (DataRow row in tables["WINE"].Select(filter))
                {
                    Console.Write("Wine: {0} \n", row["Title"]);
                    Console.Write("Description: {0} \n\n", row["Description"]);
                }
                Console.WriteLine();
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql query execution. Message: " + e.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Bad input! Message: " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Вставляет в таблицу COUNTRY
        public void thirdQueryInsert_disconnect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 3, "[Disconnected] Insert.");

            string dataCommand = @"select ID, Country from COUNTRY";
            string insertQueryString = @"insert into COUNTRY (ID, Country) values (@ID, @Country)";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");

                Console.WriteLine("Inserting a new Country. Input: ");
                Console.Write("- ID = ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("- Country = ");
                string country = Console.ReadLine();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(dataCommand, connection));
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "COUNTRY");
                DataTable table = dataSet.Tables["COUNTRY"];

                DataRow insertingRow = table.NewRow();
                insertingRow["ID"] = ID;
                insertingRow["Country"] = country;

                table.Rows.Add(insertingRow);

                Console.WriteLine("Country: ");
                foreach (DataRow row in table.Rows)
                {
                    Console.Write("{0} ", row["ID"]);
                    Console.Write("{0} \n\n", row["Country"]);
                }
                
                SqlCommand insertQueryCommand = new SqlCommand(insertQueryString, connection);
                insertQueryCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
                insertQueryCommand.Parameters.Add("@Country", SqlDbType.VarChar, 20, "Country");

                dataAdapter.InsertCommand = insertQueryCommand;
                dataAdapter.Update(dataSet, "Country");
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Bad input! " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // Удаляет из таблицы COUNTRY
        public void fourthQueryDelete_disconnect()
        {
            Console.WriteLine("".PadLeft(79, '-'));
            Console.WriteLine("Task #{0}: {1}", 4, "[Disconnected] Delete.");

            string dataCommand = @"select * from COUNTRY";
            string deleteQueryString = @"delete from COUNTRY where Country = @name";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Deleting the passenger. Input: ");
                Console.Write("- Name = ");
                string name = Console.ReadLine();
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(dataCommand, connection));
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Country");
                DataTable table = dataSet.Tables["Country"];

                string filter = "Country = '" + name + "'";
                foreach (DataRow row in table.Select(filter))
                {
                    row.Delete();
                }

                SqlCommand deleteQueryCommand = new SqlCommand(deleteQueryString, connection);
                deleteQueryCommand.Parameters.Add("@name", SqlDbType.VarChar, 85, "Country");

                dataAdapter.DeleteCommand = deleteQueryCommand;
                dataAdapter.Update(dataSet, "Country");

                Console.WriteLine("Country");
                foreach (DataRow row in table.Rows)
                {
                    Console.Write("{0} ", row["ID"]);
                    Console.Write("{0} \n", row["Country"]);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql command execution. Message: " + e.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Bad input! " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }

        // XML
        public void fifthQueryXml_disconnect()
        {
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine("Task #{0}: {1}", 5, "WriteXml.");

            string query = @"select * from WINE";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection has been opened.");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "WINE");
                DataTable table = dataSet.Tables["WINE"];

                dataSet.WriteXml("wine.xml");
                Console.WriteLine("Check the wine.xml file.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("There is a problem during the sql query execution. Message: " + e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection has been closed.");
            }
            Console.ReadLine();
        }
    }
}
