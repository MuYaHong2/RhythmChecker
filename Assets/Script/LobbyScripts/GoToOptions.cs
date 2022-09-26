using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToOptions : MonoBehaviour
{
    public void GoOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
