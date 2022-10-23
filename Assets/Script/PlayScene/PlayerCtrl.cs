using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject[] tile;
    public GameObject[,] positions=new GameObject[5,5];
    public GameObject endMenu;
    public Image hpBar;
    public EnemySpawn enemySpawn;
    public Vector3 nowPos;
    public CamaeraCtrl camaera;

    public int X;
    public int Y;

    public float HP;

    private Vector2 mousePos;
    private Vector2 transPos;

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
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            transPos = Camera.main.ScreenToWorldPoint(mousePos);
            ButtonDown();
        }
    }

    public void ButtonDown()
    {
        if (isTouch)
        {
            return;
        }
        if (doTouch)
        {
            if (transPos.x > 0 && transPos.y > 0)
            {
                Y--;
            }
            else if (transPos.x > 0 && transPos.y < 0)
            {
                X++;
            }
            else if (transPos.x < 0 && transPos.y > 0)
            {
                X--;
            }
            else if (transPos.x < 0 && transPos.y < 0)
            {
                Y++;
            }
            //doTouch = false;
            //switch (direction)
            //{
            //    case 1:
            //        X--;
            //        break;
            //    case 2:
            //        Y--;
            //        break;
            //    case 3:
            //        Y++;
            //        break;
            //    case 4:
            //        X++;
            //        break;
            //}
            if (X > 4) X = 4;
            if (X < 0) X = 0;
            if (Y > 4) Y = 4;
            if (Y < 0) Y = 0;
            nowPos = positions[X, Y].transform.position;
            enemySpawn.EnemySpown();
            enemySpawn.Attack();
            Move();
            isTouch = true;
        }
        
    }

    public void Move()
    {
        var position = new Vector3(positions[X, Y].transform.position.x, positions[X, Y].transform.position.y);
        //transform.position = position;
        transform.DOMove(position, 0.1f);
    }

    public void GetDemeg()
    {
        StartCoroutine(camaera.Shake());
        HP--;
        if (HP<=0)
        {
            End();
        }
        hpBar.fillAmount = HP / mxHP;
    }

    private void End()
    {
        Time.timeScale = 0;
        endMenu.SetActive(true);
    }
}
