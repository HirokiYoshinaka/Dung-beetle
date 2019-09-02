using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    //Playerの状態=ゲーム全体の状態と考えます
    public enum GAMEMODE
    {
        STAY_START, //スタート前
        PLAY,
        GAMEOVER,
        CLEAR,
    }
    //Playerの大きさの段階
    public enum PLAYER_LEVEL
    {
        FIRST, SECOND, THIRD, FORTH, FIFTH,
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
        /*スプライトの幅を取得する
        * マウスカーソルがスプライトの幅の範囲にあれば移動させない
        * そうすることでまっすぐ進みたいときのブレをなくす？
        */
        private float spriteWidth;
        //当たり判定の大きさ変更
        private CircleCollider2D collider2d = null;
        //SE
        private AudioSource sound = null;

        //全体の速度を指定?
        [SerializeField]
        private float GameSpeed;
        //アクセサメソッド
        public float GetSpeed()
        {
            return GameSpeed;
        }

        //集めたうんこの数
        [SerializeField]
        private int UnkoScore = 0;
        public int GetUnkoScore()
        {
            return UnkoScore;
        }

        private Animator animator = null;

        public AnimationClip walk1 = null;
        public AnimationClip walk2 = null;
        public AnimationClip walk3 = null;
        public AnimationClip walk4 = null;
        public AnimationClip walk5 = null;

        // Start is called before the first frame update
        void Start()
        {
            //Rigidbody2dコンポーネントを取得
            this.rigidbody = GetComponent<Rigidbody2D>();
            //
            sound = GetComponent<AudioSource>();
            //状態、大きさをセット
            GameMode = GAMEMODE.STAY_START;
            GameSpeed = 0;
            playerLevel = PLAYER_LEVEL.FIRST;
            //スプライトの幅を取得
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            //
            collider2d = GetComponent<CircleCollider2D>();
            //
            animator = GetComponent<Animator>();
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
        //スタート前の状態
        private void StayStart()
        {
            this.animator.speed = 0;
            //クリックするとPLAYに遷移
            //OnMouseに記述。。。設計ミス？
        }

        //ここからポップアップ処理
        private void OnMouseOver()
        {
            switch (GameMode)
            {
                case GAMEMODE.STAY_START:
                    transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    break;
                default:
                    break;
            }
        }
        private void OnMouseExit()
        {
            switch (GameMode)
            {
                case GAMEMODE.STAY_START:
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
                default:
                    break;
            }
        }
        private void OnMouseDown()
        {
            switch (GameMode)
            {
                case GAMEMODE.STAY_START:
                    transform.localScale = new Vector3(1, 1, 1);
                    sound.Play();
                    this.animator.speed = 1;
                    GameMode = GAMEMODE.PLAY;
                    break;
                default:
                    break;
            }
        }
        //ここまでポップアップのための処理

        //GAMEMODE.PLAYで呼び出される
        private void Play()
        {
            //このへんはちょいパクり
            //マウス位置座標をVector2で取得
            Vector2 pos = Input.mousePosition;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);

            //マウスがPlayerより左にあれば
            if (worldPos.x + spriteWidth / 4 < transform.position.x)
            {
                rigidbody.AddForce(new Vector2((sideMovingSpeed * -1), 0) - rigidbody.velocity);
            }
            //マウスが右にあれば
            else if (transform.position.x < worldPos.x - spriteWidth / 4)
            {
                rigidbody.AddForce(new Vector2(sideMovingSpeed, 0) - rigidbody.velocity);

            }
            //マウスが真ん中（？
            else
            {
                rigidbody.AddForce(-rigidbody.velocity);

                //rigidbody.velocity = new Vector2(0, 0);
            }

            //これは結局rigidbody使っていないせいで当たり判定が怪しくなるので却下
            // このスクリプトがアタッチされたゲームオブジェクトを、マウス位置に線形補間で追従させる
            //transform.position = Vector2.Lerp(transform.position, new Vector2(worldPos.x,transform.position.y), 1);
            // ワールド座標をPlayer位置へ変換
            //transform.position = worldPos;

            //レベルに応じて設定していく部分
            //関数分けるべきか？
            switch (playerLevel)
            {
                case PLAYER_LEVEL.FIRST:
                    sideMovingSpeed = 5.0f;
                    GameSpeed = -2.0f;
                    if (UnkoScore < 0)
                    {
                        GameMode = GAMEMODE.GAMEOVER;
                        //Gameoverのanimation
                    }
                    else if (UnkoScore >= 2)
                    {
                        ChangeLv2();
                    }
                    break;
                case PLAYER_LEVEL.SECOND:
                    GameSpeed = -2.5f;
                    if (UnkoScore < 2)
                    {
                        ChangeLv1();
                    }
                    else if (UnkoScore >= 4)
                    {
                        ChangeLv3();
                    }
                    break;

                case PLAYER_LEVEL.THIRD:
                    GameSpeed = -3.0f;
                    if (UnkoScore < 4)
                    {
                        ChangeLv2();
                    }
                    else if (UnkoScore >= 6)
                    {
                        ChangeLv4();
                    }
                    break;
                case PLAYER_LEVEL.FORTH:
                    GameSpeed = -3.5f;
                    if (UnkoScore < 6)
                    {
                        ChangeLv3();
                    }
                    else if (UnkoScore >= 8)
                    {
                        ChangeLv5();
                    }
                    break;
                case PLAYER_LEVEL.FIFTH:
                    GameSpeed = -4.0f;
                    if (UnkoScore < 8)
                    {
                        ChangeLv4();
                    }
                    break;
            }
        }

        private void ChangeLv1()
        {
            this.animator.SetTrigger("Lv1");
            collider2d.radius = 0.25f;
            playerLevel = PLAYER_LEVEL.FIRST;
        }

        private void ChangeLv2()
        {
            this.animator.SetTrigger("Lv2");
            collider2d.radius = 0.3f;
            playerLevel = PLAYER_LEVEL.SECOND;
        }

        private void ChangeLv3()
        {
            this.animator.SetTrigger("Lv3");
            collider2d.radius = 0.375f;
            playerLevel = PLAYER_LEVEL.THIRD;
        }

        private void ChangeLv4()
        {
            this.animator.SetTrigger("Lv4");
            collider2d.radius = 0.42f;
            playerLevel = PLAYER_LEVEL.FORTH;
        }

        private void ChangeLv5()
        {
            this.animator.SetTrigger("Lv5");
            collider2d.radius = 0.5f;
            playerLevel = PLAYER_LEVEL.FIFTH;
        }

        //当たり判定の処理部分
        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                //うんこに当たったときの処理
                case "Unko":
                    //スコア加算
                    UnkoScore++;
                    break;
                //石に当たったときの処理
                case "Stone":
                    //ペナルティ
                    break;
                //サボテンに当たったときの処理
                case "Cactus":
                    //ペナルティ
                    break;
                //ゴールしたとき？の処理
                case "Goal":
                    break;
                default:
                    break;
            }
        }

        //GAMEMODE.GAMEOVERで呼び出される
        private void GameOver()
        {

        }

        //GAMEMODE.CLEARで呼び出される
        private void Clear()
        {

        }


    }
}
