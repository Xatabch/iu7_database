using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions {

	private class SommeilerResult {
		public SqlInt32 Id;
		public SqlString Name;
		public SqlString Twitter;

		public SommeilerResult(SqlInt32 id, SqlString name, SqlString twitter) {
			Id = id;
			Name = name;
			Twitter = twitter;
		}
	}

	public static bool ValidateTwitter(SqlString twitter) {
		if(!twitter.Value.EndsWith("None"))
			return false;

		return true;
	}

	[SqlFunction(
		DataAccess = DataAccessKind.Read,
		FillRowMethodName = "FindInvalidTwitter_FillRow",
		TableDefinition="Id nvarchar(10), Name nvarchar(200), Twitter nvarchar(200)")]
	public static IEnumerable FindInvalidTwitter() {
		ArrayList resultCollection = new ArrayList();

		using(SqlConnection connection = new SqlConnection("context connection=true"))

			{
				connection.Open();

				using (SqlCommand selectTwitters = new SqlCommand( 
					"SELECT " + "[ID], [TasterName] ,[Twitter] " + 
					"FROM [SOMMELIER] ", connection)) {
					using (SqlDataReader twitterReader = selectTwitters.ExecuteReader()) {
						while(twitterReader.Read()) {
							SqlString twitter = twitterReader.GetSqlString(2);
							if(ValidateTwitter(twitter)) {
								resultCollection.Add(new SommeilerResult(twitterReader.GetSqlInt32(0),
									twitterReader.GetSqlString(1),
									twitter));
							}
						}
					}
				}
			}

			return resultCollection;
		}
		public static void FindInvalidTwitter_FillRow(
		object sommeilerResultObj,
		out SqlInt32 id,
		out SqlString tasterName,
		out SqlString twitter) {
			SommeilerResult sommelierResult = (SommeilerResult) sommeilerResultObj;
			
			id = sommelierResult.Id;
			tasterName = sommelierResult.Name;
			twitter = sommelierResult.Twitter;
		}
}
