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

    public static IObjectPool<GameObject>[] enemyChatter;
    public static IObjectPool<GameObject> enemyAttackRange;

    private int _X;
    private int _Y;

    private int enemyNum;

    // Start is called before the first frame update
    void Start()
    {
        enemyChatter[0] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[0]);
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

        enemyChatter[1] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[1]);
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

        enemyChatter[2] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[2]);
        }, _rook =>
        {
            _rook.gameObject.SetActive(true);
        }, _rook =>
        {
            _rook.gameObject.SetActive(false);
        }, _rook =>
        {
            Destroy(_rook.gameObject);
        }, false, 10000); 
        
        enemyChatter[3] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[3]);
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
        
        enemyChatter[4] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[4]);
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

        enemyChatter[5] = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[5]);
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


    // Update is called once per frame
    

    public void Attack()
    {
        enemyNum = Random.Range(0, 6);
        //EnemyBasicCtrl enemyBasicCtrl = enemyChatter[enemyNum].Get().GetComponent<EnemyBasicCtrl>();
        //enemyBasicCtrl.position = player.positions[player.X,player.Y].transform.position;
    }
}
