using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject Optionsui;
    public void OptionsOn()
    {
        Optionsui.SetActive(true);
    }
    public void OptionsOff()
    {
        Optionsui.SetActive(false);
    }
}
