
namespace SaveSystemLab.Models;

public class PlayerData
{
    public List<InventoryItem> Inventory { get; set; } = new();
    public int Money { get; set; } = 0;
    public float Morale { get; set; } = 1.0f;
    public List<EffectData> ActiveEffects { get; set; } = new();
    public List<int> CurrentQuestIds { get; set; } = new();
    public RespawnPoint Respawn { get; set; } = new();

}
