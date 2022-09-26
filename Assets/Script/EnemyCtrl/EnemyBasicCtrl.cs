using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class EnemyBasicCtrl : MonoBehaviour
{
    public int _x;
    public int _y;
    public Vector3 position;

    public PlayerCtrl player;
    private IObjectPool<EnemyBasicCtrl> objectPool;

    public Vector3[] range; 

    private int attackCount;
    private int maxAttackCount;
    private int _i;
    private int maxI;

    
    void Start()
    {
        //player = FindObjectOfType<PlayerCtrl>();
    }

    private void OnEnable()
    {
        if (CompareTag("Pown"))
        {
            objectPool = EnemySpawn.pown;
            maxAttackCount = 1;
        }
        //else if (CompareTag("Rook"))
        //{
        //    objectPool = EnemySpawn.night;
        //    maxAttackCount = 1;
        //}
        else if (CompareTag("Bishop"))
        {
            objectPool = EnemySpawn.bishop;
            maxAttackCount = 1;
        }
        else if (CompareTag("Night"))
        {
            objectPool = EnemySpawn.night;
            maxAttackCount = Random.Range(2, 4); ;
        }
        else if (CompareTag("Queen"))
        {
            objectPool = EnemySpawn.queen;
            maxAttackCount = 2;
        }
        else if (CompareTag("King"))
        {
            objectPool = EnemySpawn.king;
            maxAttackCount = 3;
        }
    }

    public void Attack()
    {
        print("1");
    }

    public void Ready()
    {
        if (CompareTag("Pown"))
        {
            objectPool = EnemySpawn.pown;
            maxAttackCount = 1;
        }
        //else if (CompareTag("Rook"))
        //{
        //    objectPool = EnemySpawn.night;
        //    maxAttackCount = 1;
        //}
        else if (CompareTag("Bishop"))
        {
            BishopReady();
        }
        else if (CompareTag("Night"))
        {
            PownReady();
        }
        else if (CompareTag("Queen"))
        {
            BishopReady();
        }
        else if (CompareTag("King"))
        {
            PownReady();
        }
    }
    public void PownReady()
    {
        position = player.transform.position;
        transform.position = new Vector3(position.x, 7);
        //print(player.transform.position);
        EnemySpawn.AttackRange(player.transform.position);
    }

    private void PownAttack(Vector2 endPosition)
    {
        attackCount++;
        transform.DOMove(position, 0.1f).OnComplete(() =>
        {
            if (position==player.transform.position)
            {
                player.GetDemeg();
            }
            if (attackCount==maxAttackCount)
            {
                objectPool.Release(this);
            }
        });
    }

    private void BishopReady()
    {
        range = new Vector3[5];
        maxI = 5;
        if (player.X-player.Y<=-3 || player.X - player.Y >= 3)
        {

        }
        if (player.X-player.Y == 1|| player.X - player.Y == -1)
        {
            range = new Vector3[4];
            maxI = 4;
        }
        else if (player.X - player.Y == 2 || player.X - player.Y == -2)
        {
            range = new Vector3[3];
            maxI = 3;
        }
        _i = maxI- (5-(player.X > player.Y ? player.X : player.Y));
        _x = player.X;
        _y = player.Y;
        //print("dfd");
        while (_i<maxI)
        {
            print(_i);
            //print(range[_i]);
            range[_i++] = player.positions[_x, _y].transform.position;
            //print(_x);
            //print(_y);
            _x++;
            _y++;
            //print(range[_i++]);
        }
        _i = player.X < player.Y ? player.X - 1 : player.Y - 1;
        print(player.X < player.Y ? player.X - 1 : player.Y - 1);
        _x = player.X - 1;
        _y = player.Y - 1;
        while (_i>=0)
        {
            print(range[_i]);
            print(_i);
            print(_x);
            print(_y);
            range[_i] = player.positions[_x, _y].transform.position;
            
            _x--;
            //print(_x);
            _y--;
            _i--;
            //print(range[_i--]);
        }
        print(maxI);
        for (int i = 0; i < maxI; i++)
        {
            //print(range[i]);
            GameObject attackRange = EnemySpawn.enemyAttackRange.Get();
            attackRange.transform.position = range[i];
        }
    }

    private void BishopAttack()
    {

    }

    private void RookReady()
    {

    }

    private void RookAttack()
    {

    }
}
