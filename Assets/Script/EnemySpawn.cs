using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawn : MonoBehaviour
{
    public GameObject range;
    public GameObject enemy;
    public ButtonCtrl player;
    public bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (isReady)
        {
            var position = player.positions[player.X, player.Y].transform.position;
            enemy.transform.DOMove(position, 0.1f);
            isReady = false;
        }
        else
        {
            var position = player.positions[player.X, player.Y].transform.position;
            range.transform.position = position;
            isReady = true;
        }
        
    }
}
