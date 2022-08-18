using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NodeSpawn : MonoBehaviour
{
    public GameObject []spawnPoint;
    public GameObject node;



    public float speed;

    public static IObjectPool<GameObject> _nodes;

    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        _nodes = new ObjectPool<GameObject>(() =>
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
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= speed)
        {
            for (int i = 0; i < 2; i++)
            {
                Transform _transform = _nodes.Get().GetComponent<Transform>();
                _transform.position = spawnPoint[i] .transform.position;
                spawnTime = 0;
            }
           
        }
    }
    
}
