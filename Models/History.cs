using System;

namespace Bangazon.Models;

public class History
{
  public int Id { get; set; }

  public int UserId { get; set; }

  public DateTime Date { get; set; }

  public string? Search { get; set; }

}
