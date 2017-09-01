using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenLoader : MonoBehaviour
{
    public string SceneName;
    public int DelayInSeconds;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadStartScene());
    }

    private IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(DelayInSeconds);
        SceneManager.LoadScene(SceneName);
    }
}
