//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class FakeNode : MonoBehaviour
//{
//    private SpriteRenderer sr;
//    private PlayerCtrl playerCtrl;
//    private Color color;

//    private float bitTime;

//    private bool _isTouch;
//    private bool _isEnd;
//    // Start is called before the first frame update
//    void Start()
//    {
//        playerCtrl = FindObjectOfType<PlayerCtrl>();
//        sr = GetComponent<SpriteRenderer>();
//        color = new Color(1, 1, 1, 1);
//        bitTime = GameManager.instance.bitTime;
//    }

//    private void OnEnable()
//    {
//        _isEnd = false;
//        transform.DOKill();
//        transform.DOMove(new Vector3(0, -4, 0), bitTime).SetEase(Ease.Linear);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (transform.position.x == 0)
//        {
//            if (!_isEnd)
//            {
//                _isEnd = true;
//                StartCoroutine(enumerator());
//            }
//        }
//        if (_isTouch && playerCtrl.isTouch)
//        {
//            playerCtrl.doTouch = false;
//            playerCtrl.isTouch = false;
//            _isTouch = false;
//            if (!_isEnd)
//            {
//                _isEnd = true;
//                transform.DOKill();
//                sr.DOFade(0, 0.2f).OnComplete(() => { sr.color = color; });
//                StartCoroutine(enumerator());
//            }

//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("touch"))
//        {
//            _isTouch = true;
//        }
//    }

//    private IEnumerator enumerator()
//    {
//        yield return YieldInstructionCache.WaitForSeconds(0.2f);

//        Release();
//    }
//    private void Release()
//    {
//        playerCtrl.doTouch = false;
//        playerCtrl.isTouch = false;
//        _isTouch = false;
//        NodeSpawn.fakeNodes.Release(gameObject);
//    }
//}
