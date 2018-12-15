using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace HandWrittenUDF {
	public class RandomRange {
		[Microsoft.SqlServer.Server.SqlFunction]
		public static SqlInt32 GetRandomFromGap(SqlInt32 from, SqlInt32 to) {
			Random rnd = new Random();
			return (rnd.Next() % to + from);
		}
	}
}
