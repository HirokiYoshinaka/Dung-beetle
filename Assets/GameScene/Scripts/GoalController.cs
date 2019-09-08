using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class GoalController : MonoBehaviour
    {
        //Genaratorからセットするのでpublicに
        public GameObject player = null;
        public PlayerController playerController = null;
        private new Rigidbody2D rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            //playerController = player.GetComponent<PlayerController>();
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rigidbody.velocity = new Vector2(0, playerController.GetSpeed());
            //画面外
            if (transform.position.y < -6)
            {
                //オブジェクトのDestroy
                Destroy(gameObject);
            }
        }

        //当たり判定の処理部分
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                
            }
        }
    }
}
