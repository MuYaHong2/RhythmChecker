using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagescript : MonoBehaviour
{
    public GameObject stageimgs;
    public GameObject Onepos;
    public GameObject Twopos;
    public GameObject Threepos;

    public float stagenum = 1f;

    private void Awake()
    {
        stagenum = 1f;
    }
    private void Update()
    {
        if (stagenum == 1)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Onepos.transform.position, 0.7f);
        else if(stagenum == 2)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Twopos.transform.position, 0.7f);
       else if(stagenum == 3)
            stageimgs.transform.position = Vector2.MoveTowards(stageimgs.transform.position, Threepos.transform.position, 0.7f);
    }

    public void leftbutton()
    {
        if (stagenum == 1f)
            return;
        else
            stagenum -= 1f;
    }

    public void rightbutton()
    {
        if (stagenum == 3f)
            return;
        else
            stagenum += 1f;
    }

    
}
