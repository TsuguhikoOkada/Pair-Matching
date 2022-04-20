using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{
    public enum EButtonType
    {
        NotSet,
        PairNumberBtn,
        PuzzleCategoryBtn,
    };

    [SerializeField,Header("ボタンのタイプ")]public EButtonType _buttonType = EButtonType.NotSet;


    [HideInInspector] public GameSettings.EPairNumber _pairNumber = GameSettings.EPairNumber.NotSet;


    [HideInInspector] public GameSettings.EPuzzleCategories _puzzleCategories = GameSettings.EPuzzleCategories.NotSet;

    void Start()
    {
        
    }
 
    public void SetGameOption(string GameSceneName)
    {
        var comp = gameObject.GetComponent<SetGameButton>();

        switch (comp._buttonType)
        {
            case SetGameButton.EButtonType.PairNumberBtn:
                GameSettings.Instance.SetPairNumber(comp._pairNumber);
                break;

            case EButtonType.PuzzleCategoryBtn:
                GameSettings.Instance.SetPuzzleCategories(comp._puzzleCategories);
                break;
        }

        if (GameSettings.Instance.AllSettingsReady())
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }
}
