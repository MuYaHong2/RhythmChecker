using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Stagescript : MonoBehaviour
{
    public GameObject stageimgs;
    public GameObject[] stagePos;
    

    public float movespeed;
    public int stageNum;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        stageNum = 0;
    }
    private void Update()
    {
       //  if (stageNum == 1)
       //      stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Onepos.transform.position, movespeed);
       //  else if(stageNum == 2)
       //      stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Twopos.transform.position, movespeed);
       // else if(stageNum == 3)
       //      stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Threepos.transform.position, movespeed);
    }

    private void StageMove(int num)
    {
        stageimgs.transform.DOLocalMoveX(stagePos[num].transform.localPosition.x, 0.5f);
    }

    public void leftbutton()
    {
        if (stageNum == 0)
            return;
        else
            StageMove(--stageNum);
            
    }

    public void rightbutton()
    {
        if (stageNum == 2)
            return;
        else
            StageMove(++stageNum);
    }

    public void Play()
    {
        GameManager.instance.stageNum = stageNum;
        switch ((stageNum))
        {
            case 0:
                GameManager.instance.bpm = 80;
                break;
            case 1:
                GameManager.instance.bpm = 100;
                break;
            case 2:
                GameManager.instance.bpm = 120;
                break;
        }
        GameManager.instance.bitTime = 60 / GameManager.instance.bpm;
        SoundManager.Instance.audioSource.Stop();
        SceneManager.LoadScene("PlayScene");
    }

    
}
