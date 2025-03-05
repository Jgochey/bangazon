using System;

namespace Bangazon.Models;

public class Order
{
  public int Id { get; set; }

  public int CustomerId { get; set; }

  public DateTime OrderDate { get; set; }

  public decimal Total { get; set; }

  public string PaymentMethod { get; set; }

  public string OrderStatus { get; set; }

  public bool IsOpen { get; set; }


}
