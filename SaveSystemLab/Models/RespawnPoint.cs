namespace SaveSystemLab.Models;


public class RespawnPoint
{
    public string LocationId { get; set; } = "Camp_A";
    public float FacingDirectionDegrees { get; set; } = 0f;
    public bool IsDestroyed { get; set; } = false;         // np. po ataku
    public string Climate { get; set; } = "Temperate";     // np. wpływ pogody
}
