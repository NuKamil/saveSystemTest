
namespace SaveSystemLab.Models;

public class SaveHeader
{
    public string CheckpointName { get; set; } = string.Empty;
    public DateTime SaveTime { get; set; }
    public int SaveSlot { get; set; }
}
