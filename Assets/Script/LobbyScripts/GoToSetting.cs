using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToSetting : MonoBehaviour
{
    public void GoSetting()
    {
        SceneManager.LoadScene("Setting");
    }
}
