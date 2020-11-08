using System;

namespace guard.Core.Models
{

  public enum RoleNames
  {
    Admin,
    Customer,
    Employee
  }

  public class Role
  {
    public int Id { get; set; }
    public RoleNames Name { get; set; }
  }
}
