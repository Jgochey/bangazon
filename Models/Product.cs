using System;

namespace Bangazon.Models;

public class Product
{
  public int Id { get; set; }

  public int SellerId { get; set; }

  public int CategoryId { get; set; }

  public string Title { get; set; }

  public string Description { get; set; }

  public decimal PricePerUnit { get; set; }

  public int UnitsAvailable { get; set; }


}
