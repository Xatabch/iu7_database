using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace SqlClientAdater {
	public class DataBase {
		static SqlConnection con;
		static SqlTransaction trans;

		public static void Main(string[] args)
		{
			Console.WriteLine("Start process...");
			
			using(con = new SqlConnection(
				"server=localhost;" +
				"database=testdb;" +
				"user id=sa;" + 
				"password=0765842953VaNy"))

			{
				con.Open();

				// Create COUNTRY table
				SetupTable("COUNTRY",
					"ID int PRIMARY KEY NOT NULL", 
					"Country varchar(40) NOT NULL");

				// Create DESCRIPTION table
				SetupTable("DESCRIPTION",
					"ID int PRIMARY KEY NOT NULL",
					"Description varchar(500) NOT NULL");

				// Create WINE table
				SetupTable("WINE",
					"ID int PRIMARY KEY NOT NULL", 
					"Title varchar(100) NOT NULL", 
					"Variety varchar(60) NOT NULL", 
					"Price int NOT NULL CHECK(Price > 0)",
					"Country_id int FOREIGN KEY REFERENCES COUNTRY(ID)",
					"Description_id int FOREIGN KEY REFERENCES DESCRIPTION(ID)");

				// Create SOMMELIER table
				SetupTable("SOMMELIER",
					"ID int PRIMARY KEY NOT NULL",
					"TasterName varchar(60) NOT NULL", 
					"Twitter varchar(60) NOT NULL");

				// Create denouement table
				SetupTable("WINE_SOMMELIER",
					"ID int PRIMARY KEY NOT NULL",
					"WINE_ID int FOREIGN KEY REFERENCES WINE(ID)",
					"SOMMELIER_ID int FOREIGN KEY REFERENCES SOMMELIER(ID)");


				// Insert in COUNTRY table
				trans = con.BeginTransaction();
				Insert("COUNTRY", "data/third_essense.txt", 
					"ID","Country");
				trans.Commit();

				// Insert in DESCRIPTION table
				trans = con.BeginTransaction();
				Insert("DESCRIPTION", "data/fourth_essense.txt", 
					"ID","Description");
				trans.Commit();
				
				// Insert in WINE table
				trans = con.BeginTransaction();
				Insert("WINE", "data/first_essense.txt", 
					"ID","Title", "Variety", "Price", "Country_id", "Description_id");
				trans.Commit();

				// Insert in SOMMELIER table
				trans = con.BeginTransaction();
				Insert("SOMMELIER", "data/second_essense.txt", 
					"ID","TasterName", "Twitter");
				trans.Commit();

				// Insert in denouement table
				trans = con.BeginTransaction();
				Insert("WINE_SOMMELIER", "data/fifth_essense.txt", 
					"ID","WINE_ID","SOMMELIER_ID");
				trans.Commit();

			}

			Console.WriteLine("Success...");
		}

		//First param is name of creation Table, next name of Column Params 
		static void SetupTable(string tableName, params string[] aValues)
		{
			Console.WriteLine("Setup table " + tableName + "...");

			using(SqlCommand cmd = con.CreateCommand()) {
				cmd.Transaction = trans;
				cmd.CommandText = "DROP TABLE " + tableName; // ЛОВИТ ОШИБКУ НА УРОВНЕ СУБД (IF EXIST)

				try { cmd.ExecuteNonQuery();
				} catch(SqlException e) { }

				string result = "CREATE TABLE " + tableName + 
				" ( ";

				foreach(string tmpValue in aValues)
				{
					result += tmpValue;
					result += ", ";
				}

				result += ")";

				cmd.CommandText = result;

				cmd.ExecuteNonQuery();
			}

			Console.WriteLine("Setup complete...");
		}

		static void Insert(string tableName, string filePath, params string[] colNames)
		{
			Console.WriteLine("Insert data in table " + tableName + "...");
			SqlDataAdapter adapter = new SqlDataAdapter(
				"SELECT * FROM " + tableName, con);
			adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			adapter.SelectCommand.Transaction = trans;
			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

			DataSet ds = new DataSet();
			adapter.Fill(ds, tableName);

			StreamReader objReader = new StreamReader(filePath);
			string sLine="";
			ArrayList arrText = new ArrayList();

			while (sLine != null)
			{
				sLine = objReader.ReadLine();
				if (sLine != null)
					arrText.Add(sLine);
			}
			objReader.Close();

			foreach (string sOutput in arrText)
			{
				String[] substrings = sOutput.Split("|");

				DataRow row = ds.Tables[tableName].NewRow();

				int i = 0;

				foreach(string tmpValue in colNames)
				{
					row[tmpValue] = substrings[i];
					i++;
				}

				ds.Tables[tableName].Rows.Add(row);
				row = null;
			}

			adapter.Update(ds, tableName);

            builder = null;
            adapter = null;
            ds = null;

            Console.WriteLine("Insert complete...");

		}
	}
}
