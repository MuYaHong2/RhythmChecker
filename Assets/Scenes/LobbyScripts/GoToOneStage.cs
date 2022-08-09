using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOneStage : MonoBehaviour
{
    public void GoOneStage()
    {
        SceneManager.LoadScene("");//괄호 안에 세번째 스테이지 이름 추가
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
