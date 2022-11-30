using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneDirector : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject clearMenu;
    public GameObject[] stage1Map;
    public GameObject[] stage2Map;
    public GameObject[] stage3Map;

    public bool isStart;

    private float musicTime;
    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        musicTime = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            gameTime += Time.deltaTime;
        }
        if (gameTime>=musicTime)
        {
            Clear();
        }
        //print(gameTime);
    }

    public void Clear()
    {
        Time.timeScale = 0;
        SoundManager.Instance.audioSource.Stop();
        clearMenu.SetActive(true);
        endMenu.SetActive(true);
    }

    public void End()
    {
        Time.timeScale = 0;
        SoundManager.Instance.audioSource.Stop();
        endMenu.SetActive(true);
    }

    public void ReTry()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void BackToMenu()
    {
        SoundManager.Instance.MainLobbyMusic();
        SceneManager.LoadScene("MainLobby");
    }
}
