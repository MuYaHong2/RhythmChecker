using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    
    public Transform[] hPosition;
    public Transform[] vPosition;

    public int X;
    public int Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown(int direction)
    {
        switch (direction)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        Move();
    }

    public void Move()
    {
        var position = new Vector2(hPosition[X].position.x, vPosition[Y].position.y);
        transform.position = position;
    }
}
