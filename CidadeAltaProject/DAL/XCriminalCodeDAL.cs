using CidadeAltaProject.Objects;
using System.Data;
using System.Data.SqlClient;

namespace CidadeAltaProject.DAL
{
  public class XCriminalCodeDAL
  {
    private static string connetionString = @"Data Source=DESKTOP-ET3L8GI;Initial Catalog=CidadeAltaTest;User ID=sa;Password=_senhas_2012";
    public static CriminalCode[] GetAllCriminalCodes()
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = "select * from CriminalCode";

      var command = new SqlCommand(sql, cnn);

      var dataReader = command.ExecuteReader();
      var criminalCode = new List<CriminalCode>();
      while (dataReader.Read())
      {
        criminalCode.Add(new CriminalCode()
        {
          ID = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
          Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
          Description = dataReader.GetString(dataReader.GetOrdinal("Description")),
          Penalty = dataReader.GetDecimal(dataReader.GetOrdinal("Penalty")),
          PrisonTime = dataReader.GetInt32(dataReader.GetOrdinal("PrisonTime")),
          StatusID = dataReader.GetInt32(dataReader.GetOrdinal("StatusID")),
          CreateDate = dataReader.GetDateTime(dataReader.GetOrdinal("CreateDate")),
          UpdateDate = (DateTime?)(dataReader.IsDBNull(6) ? null : dataReader[6]),
          CreateUserID = dataReader.GetGuid(dataReader.GetOrdinal("CreateUserID")),
          UpdateUserID = (Guid?)(dataReader.IsDBNull(8) ? null : dataReader[8]),
        });
      }

      cnn.Close();
      return criminalCode.ToArray();
    }

    public static CriminalCode[] GetCriminalCodesPage(string pPular)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = string.Format("select * from CriminalCode order by ID offset {0} rows fetch next 12 rows only", pPular);

      var command = new SqlCommand(sql, cnn);

      var dataReader = command.ExecuteReader();
      var criminalCode = new List<CriminalCode>();
      while (dataReader.Read())
      {
        criminalCode.Add(new CriminalCode()
        {
          ID = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
          Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
          Description = dataReader.GetString(dataReader.GetOrdinal("Description")),
          Penalty = dataReader.GetDecimal(dataReader.GetOrdinal("Penalty")),
          PrisonTime = dataReader.GetInt32(dataReader.GetOrdinal("PrisonTime")),
          StatusID = dataReader.GetInt32(dataReader.GetOrdinal("StatusID")),
          CreateDate = dataReader.GetDateTime(dataReader.GetOrdinal("CreateDate")),
          UpdateDate = (DateTime?)(dataReader.IsDBNull(6) ? null : dataReader[6]),
          CreateUserID = dataReader.GetGuid(dataReader.GetOrdinal("CreateUserID")),
          UpdateUserID = (Guid?)(dataReader.IsDBNull(8) ? null : dataReader[8]),
        });
      }

      cnn.Close();
      return criminalCode.ToArray();
    }

    public static void Insert(CriminalCode pCriminalCode)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();
      var sql = @"insert into CriminalCode (ID, Name, Description, Penalty, PrisonTime, CreateDate, CreateUserID, StatusID)
                  values(@pID, @pName, @pDescription, @pPenalty, @pPrisonTime, @pCreateDate, @pCreateUserID, @pStatusID)";

      var command = GetCriminalCommand(sql, cnn, pCriminalCode, false);

      command.ExecuteNonQuery();
    }

    private static SqlCommand GetCriminalCommand(string pSql, SqlConnection pConn, CriminalCode pCriminalCode, bool pIsUpdate)
    {
      var command = new SqlCommand(pSql, pConn);
      command.Parameters.Add("@pID", SqlDbType.Int).Value = pCriminalCode.ID;
      command.Parameters.Add("@pName", SqlDbType.VarChar).Value = pCriminalCode.Name;
      command.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = pCriminalCode.Description;
      command.Parameters.Add("@pPenalty", SqlDbType.Decimal).Value = pCriminalCode.Penalty;
      command.Parameters.Add("@pPrisonTime", SqlDbType.Int).Value = pCriminalCode.PrisonTime;
      command.Parameters.Add("@pCreateDate", SqlDbType.DateTime).Value = pCriminalCode.CreateDate;
      command.Parameters.Add("@pCreateUserID", SqlDbType.UniqueIdentifier).Value = pCriminalCode.CreateUserID;
      command.Parameters.Add("@pStatusID", SqlDbType.Int).Value = pCriminalCode.StatusID;

      if (pIsUpdate)
      {
        command.Parameters.Add("@pUpdateUserID", SqlDbType.UniqueIdentifier).Value = pCriminalCode.UpdateUserID;
        command.Parameters.Add("@pUpdateDate", SqlDbType.DateTime).Value = pCriminalCode.UpdateDate;
      }

      return command;
    }

    public static void Update(CriminalCode pCriminalCode)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();
      var sql = @"update CriminalCode set 
                  ID = @pID,
                  Name = @pName,
                  Description = @pDescription,
                  Penalty = @pPenalty,
                  PrisonTime = @pPrisonTime,
                  CreateDate = @pCreateDate,
                  CreateUserID = @pCreateUserID, 
                  StatusID = @pStatusID,
                  UpdateUserID = @pUpdateUserID,
                  UpdateDate = @pUpdateDate
                  where id = @pID
                  ";

      var command = GetCriminalCommand(sql, cnn, pCriminalCode, true);

      command.ExecuteNonQuery();
    }

    public static void Delete(CriminalCode pCriminalCode)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();
      var sql = @"delete from CriminalCode where ID = @pID";

      var command = new SqlCommand(sql, cnn);
      command.Parameters.Add("@pID", SqlDbType.Int).Value = pCriminalCode.ID;

      command.ExecuteNonQuery();
    }

    public static CriminalCode[] SearchBy(string pParam, string pColumn)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = string.Format(@"select * from CriminalCode where {0} like '%{1}%'", pColumn, pParam);

      var command = new SqlCommand(sql, cnn);

      var dataReader = command.ExecuteReader();

      var criminalCode = new List<CriminalCode>();
      while (dataReader.Read())
      {
        criminalCode.Add(new CriminalCode()
        {
          ID = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
          Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
          Description = dataReader.GetString(dataReader.GetOrdinal("Description")),
          Penalty = dataReader.GetDecimal(dataReader.GetOrdinal("Penalty")),
          PrisonTime = dataReader.GetInt32(dataReader.GetOrdinal("PrisonTime")),
          StatusID = dataReader.GetInt32(dataReader.GetOrdinal("StatusID")),
          CreateDate = dataReader.GetDateTime(dataReader.GetOrdinal("CreateDate")),
          UpdateDate = (DateTime?)(dataReader.IsDBNull(6) ? null : dataReader[6]),
          CreateUserID = dataReader.GetGuid(dataReader.GetOrdinal("CreateUserID")),
          UpdateUserID = (Guid?)(dataReader.IsDBNull(8) ? null : dataReader[8]),
        });
      }

      cnn.Close();
      return criminalCode.ToArray();
    }

    public static CriminalCode[] FilterBy(string pColumn)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = string.Format(@"select * from CriminalCode order by {0}", pColumn);

      var command = new SqlCommand(sql, cnn);

      var dataReader = command.ExecuteReader();

      var criminalCode = new List<CriminalCode>();
      while (dataReader.Read())
      {
        criminalCode.Add(new CriminalCode()
        {
          ID = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
          Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
          Description = dataReader.GetString(dataReader.GetOrdinal("Description")),
          Penalty = dataReader.GetDecimal(dataReader.GetOrdinal("Penalty")),
          PrisonTime = dataReader.GetInt32(dataReader.GetOrdinal("PrisonTime")),
          StatusID = dataReader.GetInt32(dataReader.GetOrdinal("StatusID")),
          CreateDate = dataReader.GetDateTime(dataReader.GetOrdinal("CreateDate")),
          UpdateDate = (DateTime?)(dataReader.IsDBNull(6) ? null : dataReader[6]),
          CreateUserID = dataReader.GetGuid(dataReader.GetOrdinal("CreateUserID")),
          UpdateUserID = (Guid?)(dataReader.IsDBNull(8) ? null : dataReader[8]),
        });
      }

      cnn.Close();
      return criminalCode.ToArray();
    }
  }
}
