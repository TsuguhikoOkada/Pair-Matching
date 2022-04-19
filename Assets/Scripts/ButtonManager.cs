using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>ボタンを押した時にシーン遷移するスクリプト</summary>
public class ButtonManager : MonoBehaviour
{
    /// <summary>遷移するシーンを読み込む</summary>
    /// <param name="scene_name"></param>
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name); // 指定したシーンに移動
    }
}
