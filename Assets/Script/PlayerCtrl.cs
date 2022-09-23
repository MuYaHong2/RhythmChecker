using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject[] tile;
    public GameObject[,] positions=new GameObject[5,5];
    public Image hpBar;

    public int X;
    public int Y;

    public float HP;

    private float mxHP;

    public bool doTouch;
    public bool isTouch;

    // Start is called before the first frame update
    void Start()
    {
        doTouch = false;
        mxHP = HP;
        for (int i = 0; i < tile.Length; i++)
        {
            Map tileMap = tile[i].GetComponent<Map>();
            positions[tileMap.H, tileMap.V] = tile[i];
            //print(tile[i].name);
        }
        X = 2;
        Y = 2;
        Move();
    }
    private void Update()
    {
        print(doTouch);
        hpBar.fillAmount = HP / mxHP;
    }
    public void ButtonDown(int direction)
    {
        if (doTouch)
        {
            doTouch = false;
            switch (direction)
            {
                case 1:
                    X--;
                    break;
                case 2:
                    Y--;
                    break;
                case 3:
                    Y++;
                    break;
                case 4:
                    X++;
                    break;
            }
            if (X > 4) X = 4;
            if (X < 0) X = 0;
            if (Y > 4) Y = 4;
            if (Y < 0) Y = 0;
            Move();
            isTouch = true;
        }
        
    }

    public void Move()
    {
        var position = new Vector3(positions[X, Y].transform.position.x, positions[X, Y].transform.position.y+0.1f,0);
        //transform.position = position;
        transform.DOMove(position, 0.1f);
    }
}
