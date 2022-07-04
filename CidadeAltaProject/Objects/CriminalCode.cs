namespace CidadeAltaProject.Objects
{
  public class CriminalCode
  {
    public CriminalCode(int pID, string pName, decimal pPenalty, int pPrisonTime, int pStatusID,
      DateTime pCreateDate, Guid pCreateUserID)
    {                                            
      ID = pID;                                 
      Name = pName;
      Penalty = pPenalty;
      PrisonTime = pPrisonTime;
      StatusID = pStatusID;
      CreateDate = pCreateDate;
      CreateUserID = pCreateUserID;
    }

    public CriminalCode()
    {

    }
    public int ID { get; set; }                
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Penalty { get; set; }
    public int PrisonTime { get; set; }
    public int StatusID { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public Guid CreateUserID { get; set; }
    public Guid? UpdateUserID { get; set; }
  }
}
