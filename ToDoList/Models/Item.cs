using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //In order to use [Range()]

namespace ToDoList.Models
{
  public class Item
  {
    [Required(ErrorMessage = "The item's description can't be empty!")]
    public string Description { get; set; }
    public int ItemId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your item to a category. Have you created a category yet?")]
    public int CategoryId { get; set; }
    public Category Category { get; set; } //reference navigation property : holds a reference of a single related entity
    public List<ItemTag> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}