using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawn : MonoBehaviour
{
    public GameObject range;
    public GameObject enemy;
    public PlayerCtrl player;
    public bool isReady;

    private CamaeraCtrl camaeraCtrl;

    private int _X;
    private int _Y;

    private float bitTime;
    // Start is called before the first frame update
    void Start()
    {
        camaeraCtrl = FindObjectOfType<CamaeraCtrl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (isReady)
        {
            enemy.SetActive(true);
            var readyPosition = new Vector2(range.transform.position.x, 6);
            enemy.transform.position = readyPosition;
            var position = new Vector2(range.transform.position.x, range.transform.position.y+1.2f);
            range.SetActive(false);
            var attackPosition = 
            enemy.transform.DOMove(position, 0.1f);
            if (player.X == _X && player.Y == _Y)
            {
                player.HP--;
                StartCoroutine( camaeraCtrl.Shake());
            }
            isReady = false;
        }
        else
        {
            enemy.SetActive(false);
            range.SetActive(true);
            var position = player.positions[player.X, player.Y].transform.position;
            _X = player.X;
            _Y = player.Y;
            range.transform.position = position;
            isReady = true;
        }

    }
}
