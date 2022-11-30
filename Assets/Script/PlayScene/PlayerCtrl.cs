using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject[] tile;
    public GameObject[,] positions = new GameObject[5, 5];
    public Image hpBar;
    public EnemySpawn enemySpawn;
    public Vector3 nowPos;
    public CameraCtrl cameraCtrl;
    public PlaySceneDirector director;
    public Animator animator;
    public AudioClip hitSound;

    public int X;
    public int Y;

    public float HP;

    
    private Vector2 mousePos;
    private Vector2 transPos;

    private float mxHp;

    public bool doTouch;
    public bool isTouch;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        doTouch = false;
        mxHp = HP;
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
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            transPos = Camera.main.ScreenToWorldPoint(mousePos);
            ButtonDown();
        }
    }

    private void ButtonDown()
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
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (transPos.x > 0 && transPos.y < 0)
            {
                X++;
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (transPos.x < 0 && transPos.y > 0)
            {
                X--;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (transPos.x < 0 && transPos.y < 0)
            {
                Y++;
                transform.rotation = Quaternion.Euler(0, 0, 0);
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
        animator.SetBool("isMove", true);
        var position = new Vector3(positions[X, Y].transform.position.x, positions[X, Y].transform.position.y);
        transform.DOMove(position, 0.1f).OnComplete(() =>
        {
            animator.SetBool("isMove", false); 
            
        });
    }

    public void GetDemeg()
    {
        SoundManager.Instance.audioSource.PlayOneShot(hitSound);
        cameraCtrl.StopAllCoroutines();
        cameraCtrl.isShaking = null;
        cameraCtrl.isShaking = StartCoroutine(cameraCtrl.HitShake());
        HP--;
        if (HP <= 0)
        {
            director.End();
        }

        hpBar.fillAmount = HP / mxHp;
    }

    
}