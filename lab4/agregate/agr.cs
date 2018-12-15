using System;  
using System.Data;  
using System.Data.Sql;  
using Microsoft.SqlServer.Server;  
using System.Data.SqlClient;  
using System.Data.SqlTypes;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.UserDefined, MaxByteSize = 8000)]
public struct Concatenator : IBinarySerialize
{
    private StringBuilder sb;
    public void Init()
    {
        sb = new StringBuilder();
    }

    public void Accumulate(SqlString Value)
    {
        sb.Append(Value);
        sb.Append(",");
    }

    public void Merge(Concatenator Group)
    {
        Accumulate(Group.ToString());
    }

    public override string ToString()
    {
        return sb.ToString();
    }

    public SqlString Terminate()
    {
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

    #region IBinarySerialize Members

    public void Read(System.IO.BinaryReader r)
    {
        sb = new StringBuilder();
        sb.Append(r.ReadString());
    }

    public void Write(System.IO.BinaryWriter w)
    {
        if(sb.Length > 0)
        {
            w.Write(sb.ToString());
        }
    }

    #endregion
}