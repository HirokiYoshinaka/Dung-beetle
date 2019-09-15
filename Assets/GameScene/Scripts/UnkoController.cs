using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    namespace GameScene
    {
        public class UnkoController : MonoBehaviour
        {
            //Genaratorからセットするのでpublicに
            public GameObject player = null;
            public PlayerController playerController = null;
            private new Rigidbody2D rigidbody;

            //SE
            public AudioClip Sound = null;
            AudioSource audioSource = null;
            private SpriteRenderer spriteRenderer = null;

            // Start is called before the first frame update
            void Start()
            {
                //Genaratorからセットするので不要（この設計まずいか？
                //player = GameObject.Find("Player");
                //playerController = player.GetComponent<PlayerController>();
                this.rigidbody = GetComponent<Rigidbody2D>();
                audioSource = gameObject.GetComponent<AudioSource>();
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
                    //SEを鳴らす
                    audioSource.PlayOneShot(Sound);

                    //ここでDestroyすると音まで消えてしまうので
                    //Destroy(gameObject);
                    //spriteを非表示にして対応
                    //画面外に出た際にお片付けするのでこれでおｋ
                    spriteRenderer.enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
