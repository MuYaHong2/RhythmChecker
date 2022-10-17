using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class NodeSpawn : MonoBehaviour
{
    public GameObject spawnPointR;
    public GameObject spawnPointL;
    public GameObject node;
    public GameObject fakeNode;

    public PlayerCtrl player;
    public EnemySpawn enemy;
    public TMP_Text countText;

    public float speed;

    public static IObjectPool<GameObject> nodes;
    public static IObjectPool<GameObject> fakeNodes;

    private Transform nodePos;
    private Transform _transform2;

    private float spawnTime;
    private float bitTime;
    private float errorCount;
    private bool isStart;
    private bool isEnd;
    // Start is called before the first frame update
    void Start()
    {

        bitTime = GameManager.instance.bitTime;
        StartCoroutine(Count());
        nodes = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(node);
        }, _node =>
        {
            _node.gameObject.SetActive(true);
        }, _node =>
        {
            _node.gameObject.SetActive(false);
        }, _nodes =>
        {
            Destroy(_nodes.gameObject);
        }, false, 10000);

        fakeNodes = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(fakeNode);
        }, _fakeNode =>
        {
            _fakeNode.gameObject.SetActive(true);
        }, _fakeNode =>
        {
            _fakeNode.gameObject.SetActive(false);
        }, _fakeNode =>
        {
            Destroy(_fakeNode.gameObject);
        }, false, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= bitTime)
            {
                errorCount = spawnTime - bitTime;
                nodePos = nodes.Get().GetComponent<Transform>();
                nodePos.position = spawnPointL.transform.position;
                _transform2 = fakeNodes.Get().GetComponent<Transform>();
                _transform2.position = spawnPointR.transform.position;
                //print(spawnTime);
                print(errorCount);
                spawnTime = 0;
                spawnTime += errorCount;
            }
        }
        
    }

    //public IEnumerator BitPlay()
    //{
    //    while (!isEnd != false)
    //    {
    //        Transform node = nodes.Get().GetComponent<Transform>();
    //        node.transform.position = spawnPointL.transform.position;
    //        Transform _transform2 = fakeNodes.Get().GetComponent<Transform>();
    //        _transform2.position = spawnPointR.transform.position;
    //        yield return YieldInstructionCache.WaitForSeconds(bitTime);
    //    }
    //}
    
    private IEnumerator Count()
    {
        //yield return YieldInstructionCache.w
        countText.text = "3";
        countText.transform.DOScale(1, bitTime).ChangeStartValue(new Vector3(2, 2, 2));
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        countText.text = "2";
        countText.transform.DOScale(1, bitTime).ChangeStartValue(new Vector3(2, 2, 2));
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        countText.text = "1";
        countText.transform.DOScale(1, bitTime).ChangeStartValue(new Vector3(2, 2, 2));
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        countText.text = "";
        //print(SoundManager.instance.audio);
        isStart = true;

        yield return YieldInstructionCache.WaitForSeconds(Time.deltaTime);
        SoundManager.Instance.MusicPlay();
        //StartCoroutine(BitPlay());
    }
}

