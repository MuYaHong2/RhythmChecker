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
    public int stagenum = 1;

    private void Awake()
    {
        stagenum = 1;
    }
    private void Update()
    {
        if (stagenum == 1)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Onepos.transform.position, movespeed);
        else if(stagenum == 2)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Twopos.transform.position, movespeed);
       else if(stagenum == 3)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Threepos.transform.position, movespeed);
    }

    public void leftbutton()
    {
        if (stagenum == 1)
            return;
        else
            stagenum -= 1;
    }

    public void rightbutton()
    {
        if (stagenum == 3)
            return;
        else
            stagenum += 1;
    }

    public void Play()
    {
        GameManager.instance.stageNum = stagenum-1;
        SceneManager.LoadScene("PlayScene");
    }

    
}
