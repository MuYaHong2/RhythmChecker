using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class EnemyBasicCtrl : MonoBehaviour
{
    public float x;
    public float y;
    public Vector3 position;

    private PlayerCtrl player;
    private IObjectPool<GameObject> objectPool;

    private int attackCount;
    private int maxAttackCount;
    // Start is called before the first frame update without sex yeah
    //kimnori is veryverystrong onahole user who called tanigakii 
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();
    }

    private void OnEnable()
    {
        if (CompareTag("Pown"))
        {
            objectPool = EnemySpawn.pown;
            maxAttackCount = 1;
            PownReady();
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

    private void PownReady()
    {
        position = player.transform.position;
        transform.position = new Vector3(position.x, 7);
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
                objectPool.Release(gameObject);
            }
        });
    }

    private void BishopReady()
    {

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
