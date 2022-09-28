using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject Optionsui;
    public void OptionsOn()
    {
        Optionsui.gameObject.SetActive(true);
    }
    public void OptionsOff()
    {
        Optionsui.gameObject.SetActive(false);
    }
}
