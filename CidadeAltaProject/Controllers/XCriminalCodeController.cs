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
  public class XCriminalCodeController : ControllerBase, IDisposable
  {
    private readonly ILogger<XCriminalCodeController> _logger;

    public XCriminalCodeController(ILogger<XCriminalCodeController> logger)
    {
      _logger = logger;
    }

    public void Dispose()
    {

    }

    [HttpGet("~/GetAllCriminalCodes")]
    public CriminalCode[] GetAllCriminalCodes() //Pega Todos Códigos
    {
      var criminalCode = XCriminalCodeDAL.GetAllCriminalCodes();
      return criminalCode.ToArray();
    }

    [HttpGet("~/GetCriminalCodesPage")]
    public CriminalCode[] GetCriminalCodesPage(string pPular) //Pega códigos paginados
    {
      var criminalCode = XCriminalCodeDAL.GetCriminalCodesPage(pPular);
      return criminalCode.ToArray();
    }

    [HttpGet("~/Save")]
    public void Save(CriminalCode pCriminalCode) //Salva e atualiza códigos
    {
      if (pCriminalCode.UpdateUserID == null)
        XCriminalCodeDAL.Insert(pCriminalCode);
      else
        XCriminalCodeDAL.Update(pCriminalCode);
    }

    [HttpGet("~/Excluir")]
    public void Excluir(CriminalCode pCriminalCode) //Exclui códigos
    {
      XCriminalCodeDAL.Delete(pCriminalCode);
    }

    [HttpGet("~/SearchBy")]
    public CriminalCode[] SearchBy(string pParam, string pColumn) //Procura código por coluna
    {
      try
      {
        var criminalCode = XCriminalCodeDAL.SearchBy(pParam, pColumn);
        return criminalCode;
      }
      catch (Exception)
      {
        throw new Exception();
      }
    }

    [HttpGet("~/FilterBy")]
    public CriminalCode[] FilterBy(string pColumn) //Ordena códgo por coluna
    {
      var criminalCode = XCriminalCodeDAL.FilterBy(pColumn);
      return criminalCode;
    }
  }
}
