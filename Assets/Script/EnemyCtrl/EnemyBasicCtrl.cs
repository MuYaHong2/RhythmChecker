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
            objectPool = EnemySpawn.enemyChatter[0];
            maxAttackCount = 1;
        }
        else if (CompareTag("Rook"))
        {
            objectPool = EnemySpawn.enemyChatter[2];
            maxAttackCount = 1;
        }
        else if (CompareTag("Bishop"))
        {
            objectPool = EnemySpawn.enemyChatter[3];
            maxAttackCount = 1;
        }
        else if (CompareTag("Night"))
        {
            objectPool = EnemySpawn.enemyChatter[1];
            maxAttackCount = Random.Range(2, 4); ;
        }
        else if (CompareTag("Queen"))
        {
            objectPool = EnemySpawn.enemyChatter[4];
            maxAttackCount = 2;
        }
        else if (CompareTag("King"))
        {
            objectPool = EnemySpawn.enemyChatter[5];
            maxAttackCount = 3;
        }
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
