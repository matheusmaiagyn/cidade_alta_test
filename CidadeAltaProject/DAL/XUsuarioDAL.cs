using CidadeAltaProject.Objects;
using CidadeAltaProject.Utils;
using System.Data.SqlClient;

namespace CidadeAltaProject.DAL
{
  public class XUsuarioDAL
  {
    private static string connetionString = @"Data Source=DESKTOP-ET3L8GI;Initial Catalog=CidadeAltaTest;User ID=sa;Password=_senhas_2012";
    public static Usuario Login(string pUser, string pSenha)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = String.Format("select * from Usuario where Login = '{0}'", pUser);

      var command = new SqlCommand(sql, cnn);

      var dataReader = command.ExecuteReader();
      var usuario = new Usuario();
      while (dataReader.Read())
      {
        usuario.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
        usuario.Login = dataReader.GetString(dataReader.GetOrdinal("Login"));
        usuario.Senha = dataReader.GetString(dataReader.GetOrdinal("Senha"));
      }

      cnn.Close();
      return usuario;
    }

    public static void Cadastrar(string pUser, string pSenha)
    {
      var cnn = new SqlConnection(connetionString);
      cnn.Open();

      var sql = String.Format("INSERT INTO Usuario VALUES ('{0}', '{1}', '{2}')", Guid.NewGuid(), pUser, XUtils.EncodePass(pSenha));

      var command = new SqlCommand(sql, cnn);

      command.ExecuteNonQuery();
    }
  }
}
