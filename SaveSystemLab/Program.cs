// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;
using SaveSystemLab.Models;

Console.WriteLine("Hello, World!");

var saveData = new GameSaveData
{
    Player = new PlayerData
    {
        Inventory = new List<InventoryItem>
            {
                new InventoryItem { ItemId = 1, Condition = 0.85f },
                new InventoryItem { ItemId = 5, Condition = 0.4f }
            },
        Money = 430,
        Morale = 1.0f,
        ActiveEffects = new List<EffectData>
            {
            new EffectData { Id = "exhaustion", Intensity = 0.5f, DurationSeconds = 120.0f, Source = "lack_of_sleep", Affects = new List<string> {"movement" }
            },
            new EffectData { Id = "stink", Intensity = 0.3f, DurationSeconds = 180.0f, Source = "bad_meat", Affects = new List<string> { "stealth", "trade" }
            }
        },
        Respawn = new RespawnPoint
        {
            LocationId = "Verdant Valleys",
            FacingDirectionDegrees = 90.0f,
            IsDestroyed = false,
            Climate = "Greenhollow"
        }
    },
    World = new WorldState
    {
        Reputation = new Dictionary<string, float> { { "Guards", 0.8f }, { "Outcasts", 0.2f } },
        KnownLocations = new HashSet<int> { 12, 7, 18 },
        CompletedQuests = new List<int> { 3, 6, 9 },
        Time = new GameTime
        {
            TimeOfDay = "Day",
            DayCount = 15,
            Weather = "Sunny"
        },
        Season = "Winter"

    },
    CheckpointName = "The Whispering Glade",
    SaveTime = DateTime.UtcNow,
    SaveSlot = 2
};

// string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
// Console.WriteLine(json);
// File.WriteAllText("save2.json", json);
//
// // string jsonData = File.ReadAllText("./save1.json");
// // if (string.IsNullOrEmpty(jsonData)) return;
// //
// // var deserializedData = JsonConvert.DeserializeObject<GameSaveData>(jsonData);
// //
// // if (deserializedData is not null)
// {
//     Console.WriteLine(deserializedData.Player.Money);
//
// }

List<SaveHeader> LoadSaveHeaders()
{
    List<SaveHeader> headers = new List<SaveHeader>();
    string[] directoryFiles = Directory.GetFiles("./", "*.json");
    foreach (string directoryFile in directoryFiles)
    {
        // Console.WriteLine(directoryFile);
        string jsonData = File.ReadAllText(directoryFile);
        var deserializedJsonSave = JsonConvert.DeserializeObject<SaveHeader>(jsonData);
        if (deserializedJsonSave is not null)
        {
            headers.Add(deserializedJsonSave);
        }
    }
    ;

    return headers;
}
//
List<SaveHeader> myList = LoadSaveHeaders();
// foreach (SaveHeader header in myList) Console.WriteLine(header.CheckpointName);


SaveHeader? GetHeaderBySlot(List<SaveHeader> headers, int slot)
{
    return headers.FirstOrDefault(x => x.SaveSlot == slot);
}

SaveHeader? machedHeader = GetHeaderBySlot(myList, 2);




// if (machedHeader is not null)
// {
//     Console.WriteLine($"SLOT: {machedHeader.SaveSlot}");
//     Console.WriteLine($"CHECKPOINT: {machedHeader.CheckpointName}");
//     Console.WriteLine($"TIME: {machedHeader.SaveTime}");
// }
// else
// {
//     Console.WriteLine("No save found in this slot.");
// }



void SaveGameToSlot(GameSaveData data, int slot)
{
    data.SaveSlot = slot;

    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
    File.WriteAllText($"save{slot}.json", json);
    Console.WriteLine($"Saved to slot {slot}");
}

// SaveGameToSlot(saveData, 3);


GameSaveData? LoadGameDataFromSlot(int slot)
{
    string slotToRead = $"./save{slot}.json";
    if (!File.Exists(slotToRead)) return null;

    string jsonData = File.ReadAllText(slotToRead);

    if (string.IsNullOrEmpty(jsonData)) return null;
    return JsonConvert.DeserializeObject<GameSaveData>(jsonData);
}


var loaded = LoadGameDataFromSlot(3);
if (loaded is not null)
{
    Console.WriteLine(loaded.CheckpointName);
}

