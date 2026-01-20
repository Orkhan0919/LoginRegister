using WebApplication1.Models.Base;

namespace WebApplication1.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public decimal Price {get; set;}
    
}