using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] musics;
    public AudioClip lobbyMusic;

    public AudioSource audioSource;

    public float musicTime;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SoundManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SoundManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<SoundManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        

    }

    private void Start()
    {
        MainLobbyMusic();
    }

    public void MusicPlay()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = musics[GameManager.instance.stageNum-1];
        musicTime = audioSource.clip.length;
        audioSource.Play();
    }

    public void VolumeCtrl(float i)
    {
        audioSource.volume = i;
    }

    public void MainLobbyMusic()
    {
        audioSource.clip = lobbyMusic;
        audioSource.Play();
    }
}
