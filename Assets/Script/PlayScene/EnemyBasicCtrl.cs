using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class EnemyBasicCtrl : MonoBehaviour
{
    public int x;
    public int y;
    public int num;
    public Vector3 position;

    public PlayerCtrl player;
    public EnemySpawn enemySpawn;
    public IObjectPool<EnemyBasicCtrl> objectPool;
    public GameObject[] attackRanges;

    public Vector3[] range;

    private GameObject attackRange;

    private Vector3 _startPos;
    private Vector3 _endPos;

    private int _attackCount, _maxAttackCount, _i, _maxI, _h, _startPosNum, _line, _column, _matrix;
     
    private bool _isReady;
    
    
    private void OnEnable()
    {
        _attackCount = 0;
        _isReady = false;
        if (CompareTag("Pown"))
        {
            _maxAttackCount = 1;
        }
        else if (CompareTag("Bishop"))
        {
            _maxAttackCount = 1;
        }
        else if (CompareTag("Night"))
        {
            _maxAttackCount = Random.Range(2, 4);
        }
        else if (CompareTag("Queen"))
        {
            _maxAttackCount = 2;
        }
        else if (CompareTag("King"))
        {
            _maxAttackCount = 3;
        }
    }

    public void Attack()
    {

        //print(gameObject.tag + _attackCount);

        if (_attackCount < _maxAttackCount)
        {
            if (!_isReady)
            {
                Ready();
                return;
            }
            else
            {
                _isReady = false;
                if (CompareTag("Pown"))
                {
                    PownAttack();
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
                    PownAttack();
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
                //this_is_king
                else if (CompareTag("King"))
                {
                    switch (_attackCount)
                    {
                        case 0:
                            PownAttack();
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
        
        else if(_attackCount >= _maxAttackCount)
        {
            ReleaseThis();
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
        position = player.positions[player.X, player.Y].transform.position;
        if (!gameObject.CompareTag("Night"))
        {
            transform.position = new Vector3(position.x, 7);
        }
        //print(player.transform.position);
        attackRange = EnemySpawn.AttackRange(position);
    }

    private void PownAttack()
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
            if(!(_attackCount>=_maxAttackCount))
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
        x = player.X;
        y = player.Y;
        while (_i<_maxI)
        {
            range[_i++] = player.positions[x, y].transform.position; 
            x += _h;
            y ++; 
        }
        if (player.X - player.Y <= -3 || player.X - player.Y >= 3)
        {
            _i= (player.X - player.Y) > 0 ? -1 : _maxI - 2;
            x = player.X + 1;
            y = player.Y - 1;
        }
        else
        {
            _i = (player.X < player.Y ? player.X - 1 : player.Y - 1);
            x = player.X - 1;
            y = player.Y - 1;
        }
        
        while (_i>=0)
        {
            range[_i] = player.positions[x, y].transform.position;
            
            x -=_h;
            y --;
            _i--;
        }
        for (int i = 0; i < _maxI; i++)
        {
            GameObject attackRange = EnemySpawn.enemyAttackRange.Get();
            attackRange.transform.position = range[i];
            attackRanges[i] = attackRange;
        }
        _startPosNum = Random.Range(0, 2);
        if (_h==1)
        {
            if (_attackCount==0)
            {
                switch (_startPosNum)
                {
                    case 0:
                        transform.position = new Vector3(range[0].x, 8);
                        break;
                    case 1:
                        transform.position = new Vector3(range[0].x, -8);
                        break;
                }
            }
            
        }
        else
        {
            switch (_startPosNum)
            {
                case 0:
                    transform.position = new Vector3(8, range[0].y);
                    break;
                case 1:
                    transform.position = new Vector3(-8, range[0].y);
                    break;
            }
        }
        
    }

    private void BishopAttack()
    {
        //for (int i = 0; i < range.Length-1; i++)
        //{
        //    print(range[i]);
        //}
        //int startPosNum;
        //startPosNum = Random.Range(0, 2);
        
        switch (_startPosNum)
        {
            case 0:
                _startPos = range[0];
                _endPos = range[(_maxI-1)];
                break;
            case 1:
                _startPos = range[(_maxI-1)];
                _endPos = range[0];
                break;
        }
        transform.position = _startPos;
        //print(startPos);
        transform.DOMove(_endPos, 0.25f).OnComplete(() =>
        {
            //_attackCount++;
            if (_attackCount<_maxAttackCount)
            {
                Ready();
            }
        });
        for (int i = 0; i < _maxI; i++)
        {
            EnemySpawn.enemyAttackRange.Release(attackRanges[i]);
            if (player.nowPos == range[i])
            {
                player.GetDemeg();
            }
        }
    }

    private void RookReady()
    {
        range = new Vector3[5];

        _matrix = Random.Range(0,2);
        switch (_matrix)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    range[i] = player.positions[player.X, i].transform.position;
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    range[i] = player.positions[i, player.Y].transform.position;
                }
                break;
        }
        for (int i = 0; i < 5; i++)
        {
            attackRanges[i] = EnemySpawn.enemyAttackRange.Get();
            attackRanges[i].transform.position = range[i];
            attackRanges[i].tag = gameObject.tag;
        }
        
    }

    private void RookAttack()
    {
        
        switch (_startPosNum)
        {
            case 0:
                _startPos = range[0];
                _endPos = range[4];
                break;
            case 1:
                _startPos = range[4];
                _endPos = range[0];
                break;
        }

        transform.position = _startPos;
        //print(startPos);
        
        transform.DOMove(_endPos, 0.25f).OnComplete(() =>
        {
            //_attackCount++;
            //Ready();
        });

        for (int i = 0; i < 5; i++)
        {
            EnemySpawn.enemyAttackRange.Release(attackRanges[i]);
            if (player.nowPos == range[i])
            {
                player.GetDemeg();
            }
        }
    }

    private void ReleaseThis()
    {
        enemySpawn.Delete(num);
        objectPool.Release(this);
    }
}
