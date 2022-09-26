using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;


public class EnemySpawn : MonoBehaviour
{
    public GameObject range;
    public GameObject[] enemy;
    public PlayerCtrl player;

    public static IObjectPool<EnemyBasicCtrl> pown;
    public static IObjectPool<EnemyBasicCtrl> night;
    public static IObjectPool<EnemyBasicCtrl> bishop;
    public static IObjectPool<EnemyBasicCtrl> queen;
    public static IObjectPool<EnemyBasicCtrl> king;

    public static IObjectPool<GameObject> enemyAttackRange;

    private EnemyBasicCtrl[] enemyCtrl;
    private IObjectPool<EnemyBasicCtrl> enemyChatter;

    private int _front;
    private int _rear;
    private int _maxSize;
    private int _index;

    private int enemyNum;

    private bool _isReady;

    // Start is called before the first frame update
    void Start()
    {
        _maxSize = 3;
        enemyCtrl = new EnemyBasicCtrl[100];


        pown = new ObjectPool<EnemyBasicCtrl>(() =>
        {
            return Instantiate(enemy[0]).GetComponent<EnemyBasicCtrl>();
        }, _pown =>
        {
            _pown.gameObject.SetActive(true);
        }, _pown =>
        {
            _pown.gameObject.SetActive(false);
        }, _pown =>
        {
            Destroy(_pown.gameObject);
        }, false, 10000);

        night = new ObjectPool<EnemyBasicCtrl>(() =>
        {
            return Instantiate(enemy[1]).GetComponent<EnemyBasicCtrl>();
        }, _night =>
        {
            _night.gameObject.SetActive(true);
        }, _night =>
        {
            _night.gameObject.SetActive(false);
        }, _night =>
        {
            Destroy(_night.gameObject);
        }, false, 10000);

        //enemyChatter[2] = new ObjectPool<GameObject>(() =>
        //{
        //    return Instantiate(enemy[2]);
        //}, _rook =>
        //{
        //    _rook.gameObject.SetActive(true);
        //}, _rook =>
        //{
        //    _rook.gameObject.SetActive(false);
        //}, _rook =>
        //{
        //    Destroy(_rook.gameObject);
        //}, false, 10000); 
        
        bishop = new ObjectPool<EnemyBasicCtrl>(() =>
        {
            return Instantiate(enemy[2]).GetComponent<EnemyBasicCtrl>();
        }, _bishop =>
        {
            _bishop.gameObject.SetActive(true);
        }, _bishop =>
        {
            _bishop.gameObject.SetActive(false);
        }, _bishop =>
        {
            Destroy(_bishop.gameObject);
        }, false, 10000); 
        
        queen = new ObjectPool<EnemyBasicCtrl>(() =>
        {
            return Instantiate(enemy[3]).GetComponent<EnemyBasicCtrl>();
        }, _queen =>
        {
            _queen.gameObject.SetActive(true);
        }, _queen =>
        {
            _queen.gameObject.SetActive(false);
        }, _queen =>
        {
            Destroy(_queen.gameObject);
        }, false, 10000);

        king = new ObjectPool<EnemyBasicCtrl>(() =>
        {
            return Instantiate(enemy[4]).GetComponent<EnemyBasicCtrl>();
        }, _king =>
        {
            _king.gameObject.SetActive(true);
        }, _king =>
        {
            _king.gameObject.SetActive(false);
        }, _king =>
        {
            Destroy(_king.gameObject);
        }, false, 10000);

        enemyAttackRange = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(range);
        }, _range =>
        {
            _range.gameObject.SetActive(true);
        }, _range =>
        {
            _range.gameObject.SetActive(false);
        }, _range =>
        {
            Destroy(_range.gameObject);
        }, false, 10000);
    }    

    public void EnemySpown()
    {
        if (!_isReady)
        {
            _isReady = true;
            return;
        }
        enemyNum = Random.Range(0, 5);
        switch (enemyNum)
        {
            case 0:
                enemyChatter = pown;
                break;
            case 1:
                enemyChatter = night;
                break;
            case 2:
                enemyChatter = bishop;
                break;
            case 3:
                enemyChatter = queen;
                break;
            case 4:
                enemyChatter = king;
                break;
        }
        enemyCtrl[_rear] = enemyChatter.Get().GetComponent<EnemyBasicCtrl>();
        enemyCtrl[_rear].position = player.positions[player.X, player.Y].transform.position;
        enemyCtrl[_rear].player = player;
        enemyCtrl[_rear].Ready();
        _rear = (_rear + 1) % _maxSize;
        _isReady = false;
    }

    public static void AttackRange(Vector2 position)
    {
        GameObject attackRange = enemyAttackRange.Get();
        attackRange.transform.position = position;
    }

    public void Delete()
    {
        _front = (_front + 1) % _maxSize;
    }

    public void Attack()
    {
        
    }
}
