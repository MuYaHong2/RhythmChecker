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
        musicTime = 150;
        print(musicTime);
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
            End();
        }
        print(gameTime);
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
        SceneManager.LoadScene("MainLobby");
    }
}
