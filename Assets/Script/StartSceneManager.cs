using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject[] cutScenes;
    // Start is called before the first frame update
    void Start()
    {
        cutScenes[0].SetActive(true);
        StartCoroutine(CutScenePlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CutScenePlay()
    {
        yield return YieldInstructionCache.WaitForSeconds(3);
        cutScenes[1].SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(3);
        cutScenes[2].SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(3);
        SceneManager.LoadScene("MainLobby");
    }
}
