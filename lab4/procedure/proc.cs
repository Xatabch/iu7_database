using System;  
using System.Data;  
using System.Data.Sql;  
using Microsoft.SqlServer.Server;  
using System.Data.SqlClient;  
using System.Data.SqlTypes;

public partial class MyClass
{
	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void GetAvgPrice(int price)
	{
		using (SqlConnection contextConnection = new SqlConnection("context connection = true"))
		{
			SqlCommand contextCommand = new SqlCommand("SELECT Country, AVG(Price) FROM WINE JOIN COUNTRY ON WINE.ID = COUNTRY.ID GROUP BY Country HAVING AVG(Price) > @Price", 
				contextConnection);
			contextCommand.Parameters.AddWithValue("@Price", price);
			contextConnection.Open();
			SqlDataRecord rec = new SqlDataRecord(
	                new SqlMetaData("Country", SqlDbType.NVarChar, 200)
	                );

			SqlContext.Pipe.SendResultsStart(rec);
			SqlDataReader rdr = contextCommand.ExecuteReader();
			while (rdr.Read())
	        {
	            rec.SetString(0, rdr.GetString(0));
	            SqlContext.Pipe.SendResultsRow(rec);
	        }
	        
	        SqlContext.Pipe.SendResultsEnd();
	    }
	}
}