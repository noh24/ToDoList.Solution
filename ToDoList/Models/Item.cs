using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } //reference navigation property : holds a reference of a single related entity
    public List<ItemTag> JoinEntities { get;}
  }
}