SaveSystemLab/
├── Program.cs
├── Models/
│   ├── GameSaveData.cs
│   ├── PlayerData.cs
│   ├── WorldState.cs
│   ├── EffectData.cs
│   ├── GameTime.cs
│   └── InventoryItem.cs
├── save1.json         (nasz plik zapisu)



res://
│
├── Main.tscn                  # główna scena startowa (np. menu lub świat)
├── Project.godot
│
├── Scenes/
│   ├── World/
│   │   ├── Overworld.tscn     # główny świat gry
│   │   └── SpawnPoints/       # punkty odrodzenia
│   └── UI/
│       └── SaveMenu.tscn      # później: menu sejwów
│
├── Scripts/
│   ├── Core/
│   │   └── Game.cs            # główny menedżer gry (np. singleton autoload)
│   ├── Services/
│   │   └── SaveGameManager.cs # Twoja klasa sejwów (już masz)
│   ├── Systems/
│   │   └── PlayerSpawner.cs   # odpowiedzialny za odrodzenie gracza
│   └── Data/
│       └── GameSaveData.cs    # wszystkie Twoje modele danych
│
├── Players/
│   └── Player.tscn            # prefab gracza
│
├── Saves/
│   └── save0.json             # pliki zapisów
