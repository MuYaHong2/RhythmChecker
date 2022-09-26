using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;


public class FakeNode : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerCtrl playerCtrl;
    private Color color;

    private float bitTime;

    private bool _isTouch;
    private bool _isEnd;

    public float testTime;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();
        sr = GetComponent<SpriteRenderer>();
        color = new Color(1, 1, 1, 1);
        bitTime = GameManager.instance.bitTime;
    }

    private void OnEnable()
    {
        _isEnd = false;
        transform.DOKill();
        testTime = TimeRecord.gameTime;
        //transform.DOMove(new Vector3(0, -4, 0), bitTime).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        float startPos = 6;
        float moveRange = 5.65f;

        float timeCount = TimeRecord.gameTime - testTime;
        float moveTime = bitTime;

        int direction = -1;

        var value = EaseManager.Evaluate(Ease.Linear, (f, r, t, g) => 0, timeCount, moveTime, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
        var i = Mathf.Clamp01(value);
        var 위치 = startPos + moveRange * i * direction;
        transform.position = new Vector3(위치, -4, 0);
        if (TimeRecord.gameTime - testTime >= (bitTime - 0.08) && TimeRecord.gameTime - testTime <= (bitTime + 0.08))
        {
            playerCtrl.doTouch = true;
            _isTouch = true;
        }
        else if (TimeRecord.gameTime - testTime > (bitTime + 0.08))
        {
            //print(transform.position);
            //print(time);
            NodeSpawn.fakeNodes.Release(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("touch"))
        {
            _isTouch = true;
        }
    }

    private IEnumerator enumerator()
    {
        yield return YieldInstructionCache.WaitForSeconds(0.2f);

        Release();
    }
    private void Release()
    {
        playerCtrl.doTouch = false;
        playerCtrl.isTouch = false;
        _isTouch = false;
        NodeSpawn.fakeNodes.Release(gameObject);
    }
}
