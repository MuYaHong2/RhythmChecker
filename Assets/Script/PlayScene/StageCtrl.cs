using UnityEngine;

public class StageCtrl : MonoBehaviour
{
    public GameObject[] backGround;

    public GameObject[] map;

    public GameObject witchHand;

    // Start is called before the first frame update
    void Start()
    {
        backGround[GameManager.instance.stageNum].SetActive(true);
        if (GameManager.instance.stageNum == 0)
        {
            witchHand.SetActive(true);
        }
        map[GameManager.instance.stageNum].SetActive(true);
    }

    // Update is called once per frame

}