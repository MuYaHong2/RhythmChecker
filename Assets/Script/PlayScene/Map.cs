using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int H;
    public int V;

    public Vector2 oneAnchorPoint;

    public Vector2 OneHorizontalDistance;
    public Vector2 OneVerticalDistance;
    // Start is called before the first frame update
    void Awake()
    {
        var position = oneAnchorPoint + (OneHorizontalDistance * H) + (OneVerticalDistance * V);
        transform.position = position;
    }
}
