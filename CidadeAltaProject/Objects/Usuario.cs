namespace CidadeAltaProject.Objects
{
  public class Usuario
  {
    public Usuario(Guid pID, string pName, string pSenha)
    {
      ID = pID;
      Login = pName;
      Senha = pSenha;
    }
    public Usuario()
    {

    }

    public Guid ID { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
  }
}
