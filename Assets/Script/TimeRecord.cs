using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRecord : MonoBehaviour
{
    public static float gameTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    }
}
