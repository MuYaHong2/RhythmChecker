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
    //public EnemySpawn enemySpawn;
    private IObjectPool<EnemyBasicCtrl> objectPool;
    public GameObject[] attackRanges;

    public Vector3[] range;

    private GameObject attackRange;

    private Vector3 startPos;
    private Vector3 endPos;

    private int _attackCount, _maxAttackCount, _i, _maxI, _h;

    private bool _isReady;
    
    void Start()
    {
        
    }


    private void OnEnable()
    {
        _attackCount = 0;
        if (CompareTag("Pown"))
        {
            objectPool = EnemySpawn.pown;
            _maxAttackCount = 1;
        }
        else if (CompareTag("Bishop"))
        {
            objectPool = EnemySpawn.bishop;
            _maxAttackCount = 1;
        }
        else if (CompareTag("Night"))
        {
            objectPool = EnemySpawn.night;
            _maxAttackCount = Random.Range(2, 4); ;
        }
        else if (CompareTag("Queen"))
        {
            objectPool = EnemySpawn.queen;
            _maxAttackCount = 2;
        }
        else if (CompareTag("King"))
        {
            objectPool = EnemySpawn.king;
            _maxAttackCount = 3;
        }
    }

    public void Attack()
    {
        if (_attackCount == _maxAttackCount)
        {
            print(gameObject.tag);
            objectPool.Release(this);
        }   
        else if (!_isReady)
        {
            Ready();
            return;
        }
        else
        {
            _isReady = false;
            if (CompareTag("Pown"))
            {
                PownAttack(position);
            }
            //else if (CompareTag("Rook"))
            //{
            //    objectPool = EnemySpawn.night;
            //    maxAttackCount = 1;
            //}
            else if (CompareTag("Bishop"))
            {
                BishopAttack();
            }
            else if (CompareTag("Night"))
            {
                PownAttack(position);
            }
            else if (CompareTag("Queen"))
            {
                switch (_attackCount)
                {
                    case 0:
                        BishopAttack();
                        break;
                    case 1:
                        RookAttack();
                        break;
                }
            }
            else if (CompareTag("King"))
            {
                switch (_attackCount)
                {
                    case 0:
                        PownAttack(position);
                        break;
                    case 1:
                        BishopAttack();
                        break;
                    case 2:
                        RookAttack();
                        break;
                }
                
            }
            _attackCount++;
        }
    }

    public void Ready()
    {
        if (CompareTag("Pown"))
        {
            PownReady();
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
            switch (_attackCount)
            {
                case 0:
                    BishopReady();
                    break;
                case 1:
                    RookReady();
                    break;
            }
        }
        else if (CompareTag("King"))
        {
            switch (_attackCount)
            {
                case 0:
                    PownReady();
                    break;
                case 1:
                    BishopReady();
                    break;
                case 2:
                    RookReady();
                    break;
            }
        }
        _isReady = true;
    }
    public void PownReady()
    {
        position = player.transform.position;
        if (!gameObject.CompareTag("Night"))
        {
            transform.position = new Vector3(position.x, 7);
        }
        //print(player.transform.position);
        attackRange = EnemySpawn.AttackRange(position);
    }

    private void PownAttack(Vector2 endPosition)
    {
        if (gameObject.CompareTag("Night"))
        {
            transform.position = new Vector3(position.x, 7);
        }
        EnemySpawn.enemyAttackRange.Release(attackRange);
        transform.DOMove(position, 0.1f).OnComplete(() =>
        {
            if (position==player.transform.position)
            {
                player.GetDemeg();
            }
            if(!(_attackCount==_maxAttackCount))
            {
               
                Ready();
            }
        });
    }

    private void BishopReady()
    {
        range = new Vector3[5];
        _maxI = 5;
        
        if (player.X-player.Y == 1|| player.X - player.Y == -1 || player.X - player.Y == -3 || player.X - player.Y == 3)
        {
            range = new Vector3[4];
            _maxI = 4;
        }
        else if (player.X - player.Y == 2 || player.X - player.Y == -2)
        {
            range = new Vector3[3];
            _maxI = 3;
        }
        
        if (player.X - player.Y <= -3 || player.X - player.Y >= 3)
        {
            _i = (player.X - player.Y) > 0 ? 0 : _maxI-1;
            //print(_i);
            _h = -1;
        }
        else
        {
            //print(player.X - player.Y);
            _i = _maxI - (5 - (player.X > player.Y ? player.X : player.Y));
            _h = 1;
        }
        _x = player.X;
        _y = player.Y;
        while (_i<_maxI)
        {
            range[_i++] = player.positions[_x, _y].transform.position; 
            _x += _h;
            _y ++; 
        }
        if (player.X - player.Y <= -3 || player.X - player.Y >= 3)
        {
            _i= (player.X - player.Y) > 0 ? -1 : _maxI - 2;
            _x = player.X + 1;
            _y = player.Y - 1;
        }
        else
        {
            _i = (player.X < player.Y ? player.X - 1 : player.Y - 1);
            _x = player.X - 1;
            _y = player.Y - 1;
        }
        
        while (_i>=0)
        {
            range[_i] = player.positions[_x, _y].transform.position;
            
            _x -=_h;
            _y --;
            _i--;
        }
        for (int i = 0; i < _maxI; i++)
        {
            GameObject attackRange = EnemySpawn.enemyAttackRange.Get();
            attackRange.transform.position = range[i];
            attackRanges[i] = attackRange;
        }
    }

    private void BishopAttack()
    {
        for (int i = 0; i < range.Length-1; i++)
        {
            print(range[i]);
        }
        int startPosNum;
        startPosNum = Random.Range(0, 2);
        for (int i = 0; i < _maxI; i++)
        {
            EnemySpawn.enemyAttackRange.Release(attackRanges[i]);
        }
        switch (startPosNum)
        {
            case 0:
                startPos = range[0];
                endPos = range[(_maxI-1)];
                break;
            case 1:
                startPos = range[(_maxI-1)];
                endPos = range[0];
                break;
        }
        transform.position = startPos;
        //print(startPos);
        transform.DOMove(endPos, 0.1f);
    }

    private void RookReady()
    {
    }

    private void RookAttack()
    {
        objectPool.Release(this);
    }
}
