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
        text.text = $"Volum {value * 100:F1}";
    }
}
