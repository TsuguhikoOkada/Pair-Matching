using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameButton : MonoBehaviour
{
    public enum EButtonType
    {
        NotSet,
        PairNumberBtn,
        PuzzleCategoryBtn,
    }

    [SerializeField,Header("ボタンのタイプ")]public EButtonType _buttonType = EButtonType.NotSet;


    [HideInInspector] public GameSettings.EPairNumber _pairNumber = GameSettings.EPairNumber.NotSet;


    [HideInInspector] public GameSettings.EPuzzleCategories _puzzleCategories = GameSettings.EPuzzleCategories.NotSet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
