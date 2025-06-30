
namespace SaveSystemLab.Models;

public class InventoryItem
{
    public int ItemId { get; set; }         // Unikalny identyfikator przedmiotu
    public float Condition { get; set; }    // Od 0.0 do 1.0 — stan techniczny
}
