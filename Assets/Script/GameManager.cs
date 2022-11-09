using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int stageNum;

    public float volume;
    public float bpm;
    public float bitTime;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<GameManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

    }

    private void Start()
    {
        //print(stageNum);
        //switch ((stageNum + 2))
        //{
        //    case 1:
        //        bpm = 80;
        //        break;
        //    case 2:
        //        bpm = 100;
        //        break;
        //    case 3:
        //        bpm = 120;
        //        break;
        //}
        //bitTime = 60 / bpm;
    }



}
