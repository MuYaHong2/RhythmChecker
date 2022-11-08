using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Optionsscript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void OnSliderEvent(float value)
    {
        text.text = $"{value * 100:F0}%";
        SoundManager.Instance.VolumeCtrl(value/2);
    }
}
