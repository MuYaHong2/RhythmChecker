using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int H;
    public int V;

    public Vector2 anchorPoint;

    public Vector2 hDistance;
    public Vector2 vDistance;
    // Start is called before the first frame update
    void Awake()
    {
        var position = anchorPoint + (hDistance * H) + (vDistance * V);
        transform.position = position;
    }
}
