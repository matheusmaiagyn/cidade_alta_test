using CidadeAltaProject.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using CidadeAltaProject.Utils;
using CidadeAltaProject.DAL;

namespace CidadeAltaProject.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class XUserServicesController : ControllerBase, IDisposable
  {
    private readonly ILogger<XUserServicesController> _logger;

    public XUserServicesController(ILogger<XUserServicesController> logger)
    {
      _logger = logger;
    }

    public void Dispose()
    {

    }

    [HttpGet("~/Login")]
    public Usuario Login(string pUser, string pSenha) //Login usuário
    {
      try
      {
        Usuario usuario = XUsuarioDAL.Login(pUser, pSenha);

        if (usuario.Login == null)
          return null;
        else if (pUser.ToLower() == usuario.Login.ToLower() && pSenha == XUtils.DecodePass(usuario.Senha))
          return usuario;
        else
          return null;
      }
      catch (Exception)
      {
        throw new Exception();
      }
    }

    [HttpGet("~/Cadastrar")]
    public bool Cadastrar(string pUser, string pSenha) //Cadastrar usuário
    {
      try
      {
        XUsuarioDAL.Cadastrar(pUser, pSenha);

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
