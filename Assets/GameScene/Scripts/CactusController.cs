using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class CactusController : MonoBehaviour
    {
        //Genaratorからセットするのでpublicに
        public GameObject player = null;
        public PlayerController playerController = null;
        private new Rigidbody2D rigidbody;
        //スプライト
        SpriteRenderer MainSpriteRenderer;
        public Sprite BrokenSprite;
        //SE
        public AudioClip hitSound;
        AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            //playerController = player.GetComponent<PlayerController>();
            this.rigidbody = GetComponent<Rigidbody2D>();
            MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (playerController.GetGameMode())
            {
                case GAMEMODE.STAY_START:
                    StayStart();
                    break;
                case GAMEMODE.PLAY:
                    Play();
                    break;
                case GAMEMODE.GAMEOVER:
                    GameOver();
                    break;
                case GAMEMODE.CLEAR:
                    Clear();
                    break;
            }
        }

        //GAMEMODE.STAY_STARTで呼び出される
        void StayStart()
        {

        }

        //GAMEMODE.PLAYで呼び出される
        void Play()
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
                MainSpriteRenderer.sprite = BrokenSprite;
                audioSource.PlayOneShot(hitSound);
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        //GAMEMODE.GAMEOVERで呼び出される
        void GameOver()
        {
            rigidbody.velocity = new Vector2(0, playerController.GetSpeed());
        }

        //GAMEMODE.CLEARで呼び出される
        void Clear()
        {

        }
    }
}