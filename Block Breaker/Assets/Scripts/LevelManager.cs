using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("Load level for: " +name);
        Application.LoadLevel(name);
    }

    public void BrickDestroyed()
    {
        if(Brick.TotalBricks <= 0)
        {
            Brick.TotalBricks = 0;
            LoadLevel("Level_02");
        } 
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("https://kitbanger.com");
#else
        
        Application.Quit();
#endif
    }
}
