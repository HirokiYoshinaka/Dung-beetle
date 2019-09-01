using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class GoalController : MonoBehaviour
    {
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;
        private new Rigidbody2D rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //プレイヤーの状態に応じて変化
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

        //GAMEMODE.GAMEOVERで呼び出される
        void GameOver()
        {

        }

        //GAMEMODE.CLEARで呼び出される
        void Clear()
        {

        }
    }
}
