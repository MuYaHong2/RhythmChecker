using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stagescript : MonoBehaviour
{
    public GameObject stageimgs;
    public GameObject Onepos;
    public GameObject Twopos;
    public GameObject Threepos;

    public float movespeed;
    public int stageNum = 1;

    private void Awake()
    {
        stageNum = 1;
    }
    private void Update()
    {
        if (stageNum == 1)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Onepos.transform.position, movespeed);
        else if(stageNum == 2)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Twopos.transform.position, movespeed);
       else if(stageNum == 3)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Threepos.transform.position, movespeed);
    }

    public void leftbutton()
    {
        if (stageNum == 1)
            return;
        else
            stageNum -= 1;
    }

    public void rightbutton()
    {
        if (stageNum == 3)
            return;
        else
            stageNum += 1;
    }

    public void Play()
    {
        GameManager.instance.stageNum = stageNum;
        switch ((stageNum))
        {
            case 1:
                GameManager.instance.bpm = 80;
                break;
            case 2:
                GameManager.instance.bpm = 100;
                break;
            case 3:
                GameManager.instance.bpm = 120;
                break;
        }
        GameManager.instance.bitTime = 60 / GameManager.instance.bpm;
        SceneManager.LoadScene("PlayScene");
    }

    
}
