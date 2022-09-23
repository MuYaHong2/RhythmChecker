using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Game.Enemy
{
    public class EnemyBasicCtrl : MonoBehaviour
    {
        public float x;
        public float y;
        public Vector2 position;

        private PlayerCtrl player;
        // Start is called before the first frame update without sex yeah
        //kimnori is veryverystrong onahole user who called tanigakii 
        void Start()
        {
            player = FindObjectOfType<PlayerCtrl>();
        }

        private void PownReady()
        {
            EnemySpawn.enemyAttackRange.Get();
        }

        private void PownAttack(Vector2 endPosition)
        {

        }

        private void BishopReady()
        {

        }

        private void BishopAttack()
        {

        }

        private void RookReady()
        {

        }

        private void RookAttack()
        {

        }
    }
}

