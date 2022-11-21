using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private  float _x;
    private  float _y;

    // Start is called before the first frame update


    // Update is called once per frame


    public IEnumerator Shake()
    {
        print("dfdfdf");
        for (int i = 0; i < 5; i++)
        {
            _x = Random.Range(-0.5f, 0.5f);
            _y = Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(_x, _y, -10);
            yield return YieldInstructionCache.WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(0, 0, -10);
    }

    public IEnumerator HitShake()
    {
        for (int i = 0; i < 5; i++)
        {
            _x = Random.Range(-0.1f, 0.1f);
            _y = Random.Range(-0.1f, 0.1f);
            transform.position = new Vector3(_x, _y, -10);
            yield return YieldInstructionCache.WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(0, 0, -10);
    }
}
