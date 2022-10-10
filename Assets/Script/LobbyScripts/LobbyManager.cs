using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject[] window;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WindowOnOf(int num, bool i)
    {
        if (i)
        {
            window[num].SetActive(true);
        }
        else
        {
            window[num].SetActive(false);
        }
    }

    public void GoToStage(int num)
    {
        switch (num)
        {
            case 0:
                GameManager.instance.bpm = 120;
                break;
        }
        GameManager.instance.stageNum = num;
        GameManager.instance.bitTime = 60 / GameManager.instance.bpm;
        SceneManager.LoadScene("PlayScene");
    }

    public void End()
    {
        Application.Quit();
    }
}
