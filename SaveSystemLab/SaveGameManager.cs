using System.Diagnostics;
using Newtonsoft.Json;
using SaveSystemLab.Models;

namespace SaveSystemLab;

public static class SaveGameManager
{
    // Publiczne API gry:
    public static void SaveToSlot(GameSaveData data, int slot)
    {
        data.SaveSlot = slot;
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        try
        {
            File.WriteAllText($"save{slot}.json", json);
            Debug.WriteLine($"File saved successfully on {slot}.");
        }
        catch (Exception err)
        {
            Debug.WriteLine($"Error during save file: {err.Message}");
        }
    }

    public static GameSaveData? LoadFromSlot(int slot)
    {
        string saveFile = $"./save{slot}.json";
        if (!File.Exists(saveFile)) return null;

        string jsonData = File.ReadAllText(saveFile);
        if (string.IsNullOrEmpty(jsonData)) return null;
        try
        {
            Debug.WriteLine($"File {saveFile} loaded successfully");
            return JsonConvert.DeserializeObject<GameSaveData>(jsonData);
        }
        catch (Exception err)
        {
            Debug.WriteLine($"Error during loading file: {err.Message}");
            return null;
        }
    }

    public static List<SaveHeader> GetAllHeaders()
    {
        List<SaveHeader> headers = new List<SaveHeader>();
        string[] saveFiles = Directory.GetFiles("./", "*.json");
        if (saveFiles.Length == 0) return headers;
        foreach (string saveFile in saveFiles)
        {
            string jsonData = File.ReadAllText(saveFile);

            try
            {
                var desJson = JsonConvert.DeserializeObject<SaveHeader>(jsonData);
                if (desJson is not null)
                {
                    headers.Add(desJson);
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine($"Error during loading header: {err.Message}");
                return headers;
            }
        }
        return headers;
    }


    public static SaveHeader? GetHeaderBySlot(int slot)
    {
        List<SaveHeader> headers = GetAllHeaders();
        return headers.FirstOrDefault(x => x.SaveSlot == slot);
    }
}
