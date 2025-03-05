using System;

namespace Bangazon.Models;

public class Profile
{
  public int Id { get; set; }

  public int UserId { get; set; }

  public string? FirstName { get; set; }

  public string? LastName { get; set; }

  public string? Email { get; set; }

  public string? Address { get; set; }

  public string? Phone { get; set; }

  public string? Picture { get; set; }


}
