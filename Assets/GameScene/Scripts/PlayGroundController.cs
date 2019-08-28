using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hunkoro
{
    /// <summary>
    /// 背景（その他のオブジェクトも）を動かすことで
    /// Playerのy軸を移動させずに縦移動しているかのように見せかけます。
    /// </summary>
    public class PlayGroundController : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        private PlayerController playerController;
        //
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
            if (transform.position.y < -15)
            {
                transform.position = new Vector3(0, transform.position.y + 40, 0);
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
