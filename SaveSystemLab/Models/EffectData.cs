
namespace SaveSystemLab.Models;

public class EffectData
{
    public string Id { get; set; } = string.Empty;        // np. "exhaustion"
    public float Intensity { get; set; }                  // np. 0.5 oznacza umiarkowany efekt
    public float DurationSeconds { get; set; }            // ile jeszcze potrwa
    public string Source { get; set; } = string.Empty;    // np. "injury", "potion"
    public List<string> Affects { get; set; } = new();    // np. ["movement", "dialogue"]
}
