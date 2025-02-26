using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureUIManager : MonoBehaviour
{
    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
