using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class Node : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerCtrl playerCtrl;
    private EnemySpawn enemySpawn;

    private Color color;

    private bool _isTouch;
    private bool _isEnd;

    private float time;

    private float bitTime;

    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        sr = GetComponent<SpriteRenderer>();
        color=new Color(1,1,1,1);
        bitTime = GameManager.instance.bitTime;
    }

    private void OnEnable()
    {
        _isEnd = false;
        //sr.DOKill();
        transform.DOKill();
        spawnTime = TimeRecord.gameTime;

        time = 0;
        //transform.DOMove(new Vector3(0, -4, 0), bitTime).SetEase(Ease.Linear);//.OnComplete(() => { NodeSpawn._nodes.Release(gameObject); });
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        float startPos = -6;
        float moveRange = 5.65f;

        float timeCount = TimeRecord.gameTime-spawnTime;
        float moveTime = bitTime;

        int direction = 1;

        var value = EaseManager.Evaluate(Ease.Linear, (f, r, t, g) => 0, timeCount, moveTime, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
        var i = Mathf.Clamp01(value);
        var 위치 = startPos + moveRange * i * direction;
        //print(TimeRecord.gameTime-testTime);
        transform.position = new Vector3(위치, -4, 0);
        if (TimeRecord.gameTime - spawnTime>=(bitTime-0.05)&& TimeRecord.gameTime - spawnTime <= (bitTime + 0.062))
        {
            playerCtrl.doTouch = true;
            //_isTouch = true;
        }
        else if(TimeRecord.gameTime - spawnTime > (bitTime + 0.062))
        {
            print(transform.position);
            print(time);
            NodeSpawn.nodes.Release(gameObject);
        }

        //if (transform.position.x==0)
        //{
        //    if (!_isEnd)
        //    {
        //        _isEnd = true;
        //        StartCoroutine(enumerator());
        //    }
        //}
        if (_isTouch && playerCtrl.isTouch)
        {
            playerCtrl.doTouch = false;
            _isTouch = false;
            
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("touch"))
    //    {
    //        playerCtrl.doTouch = true;
    //        _isTouch = true;
    //    }
    //}

    //private IEnumerator enumerator()
    //{
    //    yield return YieldInstructionCache.WaitForSeconds(0.01f);

    //    Release();
    //}

    //private void Release()
    //{
    //    print(time);
    //    enemySpawn.Attack();
    //    playerCtrl.doTouch = false;
    //    playerCtrl.isTouch = false;
    //    _isTouch = false;
    //    NodeSpawn.nodes.Release(gameObject);
    //}
}
