using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Beat : MonoBehaviour
{
    private SpriteRenderer sr;
    private ButtonCtrl buttonCtrl;
    private NodeSpawn nodeSpawn;
    private Color color;

    private bool _isTouch;
    private bool _isEnd;

    // Start is called before the first frame update
    void Start()
    {
        buttonCtrl = FindObjectOfType<ButtonCtrl>();
        sr = GetComponent<SpriteRenderer>();
        color=new Color(1,1,1,1);
    }

    private void OnEnable()
    {
        _isEnd = false;
        //sr.DOKill();
        transform.DOKill();
        transform.DOMove(new Vector3(0, -4, 0), 1.5f).SetEase(Ease.Linear);//.OnComplete(() => { NodeSpawn._nodes.Release(gameObject); });
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x==0)
        {
            if (!_isEnd)
            {
                _isEnd = true;
                StartCoroutine(enumerator());
            }
        }
        if (_isTouch && buttonCtrl.isTouch)
        {
            buttonCtrl.doTouch = false;
            buttonCtrl.isTouch = false;
            _isTouch = false;
            if (!_isEnd)
            {
                _isEnd = true;
                transform.DOKill();
                sr.DOFade(0, 0.2f).OnComplete(() => { sr.color = color; });
                StartCoroutine(enumerator());
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("touch"))
        {
            buttonCtrl.doTouch = true;
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
        buttonCtrl.doTouch = false;
        buttonCtrl.isTouch = false;
        _isTouch = false;
        NodeSpawn._nodes.Release(gameObject);
    }
}
