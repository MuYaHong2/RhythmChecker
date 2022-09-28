using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToMainLobby : MonoBehaviour
{
    public void GoMainLobby()
    {
        SceneManager.LoadScene("MainLobby");
    }
}
