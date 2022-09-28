using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTwoStage : MonoBehaviour
{
    public void GoTwoStage()
    {
        SceneManager.LoadScene("");//괄호 안에 두번째 스테이지 이름 추가
    }
}
