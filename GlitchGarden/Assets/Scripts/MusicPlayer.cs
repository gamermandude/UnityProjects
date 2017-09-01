using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class SceneMusic
{
    public string SceneName;
    public AudioClip[] music;
    public bool Loop;
}

public class MusicPlayer : MonoBehaviour
{
    public SceneMusic[] Clips;
    private AudioSource source;
    private Dictionary<string, SceneMusic> SceneMusic;

    void Start()
    {
        SceneMusic = new Dictionary<string, SceneMusic>();
        foreach(var clip in Clips)
        {
            SceneMusic.Add(clip.SceneName, clip);
        }
        source = GetComponent<AudioSource>();
        if (!source)
        {
            source = gameObject.AddComponent<AudioSource>();
        }

        Debug.Log("Music player start!");
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        DontDestroyOnLoad(gameObject);
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(musicPlayer != null)
        {
            Debug.Log("Stop the music!");
            StopCoroutine(musicPlayer);
            PlayMusic = false;
            source.Stop();
        }
        Debug.Log("New scene! " + scene.name);
        musicPlayer = StartCoroutine(SetMusic(SceneMusic[scene.name]));
    }

    private bool PlayMusic;
    private Coroutine musicPlayer;
    private IEnumerator SetMusic(SceneMusic clip)
    {
        PlayMusic = true;
        int numberOfSongs = clip.music.Length;
        Debug.Log(numberOfSongs + " songs to play");
        if (numberOfSongs == 0)
        {
            yield break;
        }

        int currentTrack = 0;

        Debug.Log("Setting Music! " + clip.music[currentTrack].name);
        var time = Time.time;
        Debug.Log("Time is: " + time + " clip length is " + clip.music[currentTrack].length + " next track at " + (time + clip.music[currentTrack].length));
        source.clip = clip.music[currentTrack];
        source.Play();

        while (PlayMusic)
        {
            yield return new WaitForSeconds(0.1f);
            
            //if(time + clip.music[currentTrack].length > Time.time)
            if(!source.isPlaying)
            {
                Debug.Log("Current time is: " + Time.time);
                currentTrack++;
                if (currentTrack + 1 > numberOfSongs)
                {
                    if (clip.Loop)
                    {
                        currentTrack = 0;
                    }
                    else
                    {
                        Debug.Log("Bailing out because loop false and currentTrack greater than number of songs. " + currentTrack + " " + numberOfSongs);
                        PlayMusic = false;
                        yield break;
                    }
                }

                Debug.Log("Next track! " + clip.music[currentTrack].name);
                source.clip = clip.music[currentTrack];
                time = Time.time;
                source.Play();
            }
        }
    }
}
