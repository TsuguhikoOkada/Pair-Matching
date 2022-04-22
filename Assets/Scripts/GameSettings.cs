using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    readonly Dictionary<EPuzzleCategories,string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories,string>();

    int _settings;

    const int SettingsNumber = 2;

    public enum EPairNumber
    {
        NotSet = 0,
        E10Pairs = 10,
        E15Pairs = 15,
        E20Pairs = 20,
    }

    public enum EPuzzleCategories
    {
        NotSet,
        Type1,
        Type2,
    }

    public struct Settings
    {
        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;
    };

    Settings _gameSettings;

    public static GameSettings Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(target: this);
            Instance = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }
    void Start()
    {
        SetPuzzleCatDirectory();
        _gameSettings = new Settings();
        ResetGameSettings();
    }

    void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EPuzzleCategories.Type1, "Type1");

        _puzzleCatDirectory.Add(EPuzzleCategories.Type2, "Type2");
    }
    public void SetPairNumber(EPairNumber Number)
    {
        if (_gameSettings.PairsNumber == EPairNumber.NotSet)
        {
            _settings++;
        }

        _gameSettings.PairsNumber = Number;
    }

    public void SetPuzzleCategories(EPuzzleCategories cat)
    {
        if (_gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
        {
            _settings++;
        }

        _gameSettings.PuzzleCategory = cat;
    }

    public EPairNumber GetPairNumber()
    {
        return _gameSettings.PairsNumber;
    }

    public EPuzzleCategories GetPuzzleCategory()
    {
        return _gameSettings.PuzzleCategory;
    }

    public void ResetGameSettings()
    {
        _settings = 0;
        _gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
        _gameSettings.PairsNumber = EPairNumber.NotSet;
    }

    public bool AllSettingsReady()
    {
        return _settings == SettingsNumber;
    }

    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }

    public string GetPuzzleCategoryTextureDirectoryName()
    {
        if (_puzzleCatDirectory.ContainsKey(_gameSettings.PuzzleCategory))
        {
            return "Graphics/PuzzleCat" + _puzzleCatDirectory[_gameSettings.PuzzleCategory];
        }
        else
        {
            Debug.LogError("ERROR: CANNOT GET DIRECTORY NAME");

            return "";
        }
    }
}
