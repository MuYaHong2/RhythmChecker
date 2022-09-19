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

    private float bitTime;

    private bool _isTouch;
    private bool _isEnd;

    private float time;

    public float testTime;

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
        

        
        //transform.DOMove(new Vector3(0, -4, 0), bitTime).SetEase(Ease.Linear);//.OnComplete(() => { NodeSpawn._nodes.Release(gameObject); });
        time = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        float �̵�������ǥX = -6;
        float �̵��Ÿ� = 6;

        float ����ð� = TimeRecord.gameTime;
        float �̵��ð� = 1;

        int ���� = 1;

        var value = EaseManager.Evaluate(Ease.Linear, (f, r, t, g) => 0, ����ð�, �̵��ð�, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);

        var ��ġ = �̵�������ǥX + �̵��Ÿ� * value * ����;

        transform.position = new Vector3(��ġ, -4, 0);
        time += Time.deltaTime;
        //if (transform.position.x==0)
        //{
        //    if (!_isEnd)
        //    {
        //        _isEnd = true;
        //        StartCoroutine(enumerator());
        //    }
        //}
        //if (_isTouch && playerCtrl.isTouch)
        //{
        //    playerCtrl.doTouch = false;
        //    _isTouch = false;
        //    if (!_isEnd)
        //    {
        //        _isEnd = true;
        //        transform.DOKill();
        //        sr.DOFade(0, 0.2f).OnComplete(() => { sr.color = color; });
        //        StartCoroutine(enumerator());
        //    }
            
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("touch"))
        {
            playerCtrl.doTouch = true;
            _isTouch = true;
        }
    }

    private IEnumerator enumerator()
    {
        yield return YieldInstructionCache.WaitForSeconds(0.01f);

        Release();
    }

    private void Release()
    {
        print(time);
        enemySpawn.Attack();
        playerCtrl.doTouch = false;
        playerCtrl.isTouch = false;
        _isTouch = false;
        NodeSpawn.nodes.Release(gameObject);
    }
}
