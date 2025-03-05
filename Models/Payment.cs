using System;

namespace Bangazon.Models;

public class Payment
{
  public int Id { get; set; }

  public int OrderId { get; set; }

  public string? PaymentMethod { get; set; }

  public DateTime PaymentDate { get; set; }

  public decimal Total { get; set; }

}
