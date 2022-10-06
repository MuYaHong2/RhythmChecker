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

    private float spawnTime;

    private float bitTime;
    private bool isStart;
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
                Transform node = nodes.Get().GetComponent<Transform>();
                node.transform.position = spawnPointR.transform.position;
                Transform _transform2 = fakeNodes.Get().GetComponent<Transform>();
                _transform2.position = spawnPointL.transform.position;
                spawnTime = 0;
            }
        }
        
    }
    
    private IEnumerator Count()
    {
        countText.text = "1";
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        countText.text = "2";
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        countText.text = "3";
        yield return YieldInstructionCache.WaitForSeconds(bitTime);
        isStart = true;
    }
}

