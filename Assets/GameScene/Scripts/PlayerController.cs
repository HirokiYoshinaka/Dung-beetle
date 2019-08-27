using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    //Playerの状態=ゲーム全体の状態
    public enum GAMEMODE
    {
        STAY_START, PLAY, GAMEOVER, CLEAR,
    }
    //Playerの大きさの段階
    public enum PLAYER_LEVEL
    {
        FIRST, SECOND, THIRD,
    }
    /// <summary>
    /// "Player"の挙動を記述します。
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        //状態
        [SerializeField]
        private GAMEMODE GameMode;
        //アクセサメソッド
        public GAMEMODE GetGameMode()
        {
            return GameMode;
        }
        //レベル
        [SerializeField]
        private PLAYER_LEVEL playerLevel;
        //アクセサメソッド
        public PLAYER_LEVEL GetPlayerLevel()
        {
            return playerLevel;
        }
        //移動に使うので取得
        private new Rigidbody2D rigidbody;
        //横移動の速度
        [SerializeField]
        private float sideMovingSpeed;

        //全体の速度を指定?
        [SerializeField]
        private float GameSpeed;
        //アクセサメソッド
        public float GetSpeed()
        {
            return GameSpeed;
        }


        // Start is called before the first frame update
        void Start()
        {
            //Rigidbody2dコンポーネントを取得
            this.rigidbody = GetComponent<Rigidbody2D>();
            //状態、大きさをセット
            GameMode = GAMEMODE.PLAY;
            playerLevel = PLAYER_LEVEL.FIRST;
        }

        // Update is called once per frame
        void Update()
        {


            switch (GameMode)
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
            //このへんはちょいパクり
            //マウス位置座標をVector2で取得
            Vector2 pos = Input.mousePosition;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);
            //マウスがPlayerより左にあれば
            if (worldPos.x < transform.position.x)
            {
                rigidbody.AddForce(new Vector2((sideMovingSpeed * -1), 0));
            }
            //マウスが右にあれば
            else if (transform.position.x < worldPos.x)
            {
                rigidbody.AddForce(new Vector2(sideMovingSpeed, 0), ForceMode2D.Force);

            }

            // ワールド座標をPlayer位置へ変換
            //transform.position = worldPos;

            switch (playerLevel)
            {
                case PLAYER_LEVEL.FIRST:
                    sideMovingSpeed = 2.0f;
                    break;
                case PLAYER_LEVEL.SECOND:
                    break;
                case PLAYER_LEVEL.THIRD:
                    break;
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

        public static explicit operator PlayerController(GameObject v)
        {
            throw new NotImplementedException();
        }
    }
}
