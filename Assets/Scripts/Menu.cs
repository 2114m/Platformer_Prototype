using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    
    public void GameStart()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    
    
    
    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
