using System;

namespace Bangazon.Models;

public class User
{
  public int Id { get; set; }

  public string Name { get; set; }

  public string Password { get; set; }

  public string Email { get; set; }

// This is the unique identifier for the user in Firebase
  public string Uid { get; set; }

  public bool IsRegistered { get; set; }
}
