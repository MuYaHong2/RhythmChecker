using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int H;
    public int V;

    public Vector2 oneAnchorPoint;
    public Vector2 oneHorizontalDistance;
    public Vector2 oneVerticalDistance;

    public Vector2 twoAnchorPoint;
    public Vector2 twoHorizontalDistance;
    public Vector2 twoVerticalDistance;
    // Start is called before the first frame update
    void Awake()
    {
        var position = oneAnchorPoint + (oneHorizontalDistance * H) + (oneVerticalDistance * V);
        transform.position = position;
    }
}
