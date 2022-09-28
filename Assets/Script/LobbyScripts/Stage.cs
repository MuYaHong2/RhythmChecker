using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject stageui;
    public void StageOn()//.
    {
        stageui.SetActive(true);
    }
    public void StageOff()
    {
        stageui.SetActive(false);
    }
}
