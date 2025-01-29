using System.ComponentModel.DataAnnotations;

namespace BusinessApp.Entities
{
  public abstract class Entity<TId, TCreatedTime>
  {
    [Key]
    public TId? Id { get; set; }
    public TCreatedTime? CreatedDate { get; set; }
    protected Entity()
    {
      if (typeof(TCreatedTime) == typeof(DateTime))
      {
        CreatedDate = (TCreatedTime)(object)DateTime.Now.Date; // Yalnızca tarih kısmını alır

      }
    }
  }
}