using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hunkoro
{
    namespace GameScene
    {
        /// <summary>
        /// "ハゲワシ"の制御部分
        /// </summary>
        public class EnemyBirdController : MonoBehaviour
        {
            [SerializeField]
            private PlayerController player = null;
            [SerializeField]
            private AudioClip audioClip = null;

            private new Rigidbody2D rigidbody2D = null;
            private AudioSource audioSource = null;
            // Start is called before the first frame update
            void Start()
            {
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
                rigidbody2D = GetComponent<Rigidbody2D>();
                audioSource = GetComponent<AudioSource>();
                StartCoroutine(Entry());
            }

            private IEnumerator Entry()
            {
                //影が少しずつ拡大してくる部分
                //だからマジックナンバーをやめろっつってんだろハゲ
                for (int i = 0; i < 18; i++)
                {
                    transform.localScale += new Vector3(0.05f, 0.05f, 0);
                    yield return new WaitForSeconds(0.2f);
                }
                StartCoroutine(Move());
            }

            private IEnumerator Move()
            {
                //この時点でのPlayerの位置を目標とする
                Vector3 targetPos = player.transform.position;
                while (true)
                {
                    yield return null;
                    if(Mathf.Abs(targetPos.x-transform.position.x)<0.2f)
                    {
                        rigidbody2D.velocity = new Vector2(0, 0);
                        break;
                    }
                    rigidbody2D.AddForce(targetPos - transform.position);
                }
                StartCoroutine(Attack());
            }

            private IEnumerator Attack()
            {
                audioSource.PlayOneShot(audioClip);
                yield return new WaitForSeconds(0.1f);
                var collider = GetComponent<BoxCollider2D>();
                collider.enabled = true;
            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}