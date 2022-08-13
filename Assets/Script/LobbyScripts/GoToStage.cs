using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToStage : MonoBehaviour
{
    public void GoStage()
    {
        SceneManager.LoadScene("Stages");
    }
}
