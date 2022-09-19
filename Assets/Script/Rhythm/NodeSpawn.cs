using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NodeSpawn : MonoBehaviour
{
    public GameObject spawnPointR;
    public GameObject spawnPointL;
    public GameObject node;
    public GameObject fakeNode;


    public float speed;

    public static IObjectPool<GameObject> nodes;
    public static IObjectPool<GameObject> fakeNodes;

    private float spawnTime;

    private float bitTime;
    // Start is called before the first frame update
    void Start()
    {
        bitTime = GameManager.instance.bitTime;
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
        spawnTime += Time.deltaTime;
        if (spawnTime >= bitTime)
        {
            Transform _transform1 = nodes.Get().GetComponent<Transform>();
            _transform1.position = spawnPointR.transform.position;
            Transform _transform2 = fakeNodes.Get().GetComponent<Transform>();  
            _transform2.position = spawnPointL.transform.position;
            spawnTime = 0;          
        }
    }
    
}
