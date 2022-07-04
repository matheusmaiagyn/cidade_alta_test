namespace CidadeAltaProject.Objects
{
  public class Status
  {
    public Status(Guid pID, string pName)
    {
      ID = pID;
      Name = pName;
    }

    public Guid ID { get; set; }
    public string Name { get; set; }
  }
}
