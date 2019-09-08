using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Lv1 = 1,
        Lv2, Lv3, Lv4, Lv5,
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
        private static int UnkoScore = 0;
        public static int GetUnkoScore()
        {
            return UnkoScore;
        }
        //時間
        [SerializeField]
        private static float timeScore = 0;
        public static float GetTimeScore()
        {
            return timeScore;
        }

        //アニメーション
        private Animator animator = null;
        //BGM
        [SerializeField]
        private BGMManager BGM = null;

        //ゲームオーバー演出
        [SerializeField]
        private GameObject gameOver = null;
        //クリア演出
        [SerializeField]
        private GameObject clear = null;

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
            playerLevel = PLAYER_LEVEL.Lv1;

            //スプライトの幅を取得
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            //
            collider2d = GetComponent<CircleCollider2D>();
            //
            animator = GetComponent<Animator>();

            this.animator.SetInteger("Level", 1);
            this.animator.speed = 0;
            UnkoScore = 0;
            timeScore = 0;
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
                    var child = transform.Find("ClickHere").gameObject;
                    child.SetActive(false);
                    StartCoroutine(StartAnimation());
                    BGM.StartPlayBGM();
                    GameMode = GAMEMODE.PLAY;
                    break;
                default:
                    break;
            }
        }
        //ここまでポップアップのための処理

        private IEnumerator StartAnimation()
        {
            var child = transform.Find("GoToGoal").gameObject;
            child.SetActive(true);
            yield return new WaitForSeconds(1);
            child.SetActive(false);
        }

        //GAMEMODE.PLAYで呼び出される
        private void Play()
        {
            //timeScoreを数える
            timeScore += Time.deltaTime;

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
                case PLAYER_LEVEL.Lv1:
                    sideMovingSpeed = 5.0f;
                    GameSpeed = -2.0f;
                    if (UnkoScore < 0)
                    {
                        ChangeGameOver();
                        //Gameoverのanimation
                    }
                    else if (2 <= UnkoScore)
                    {
                        ChangeLv2();
                    }
                    break;
                case PLAYER_LEVEL.Lv2:
                    GameSpeed = -2.5f;
                    if (UnkoScore < 2)
                    {
                        ChangeLv1();
                    }
                    else if (4 <= UnkoScore)
                    {
                        ChangeLv3();
                    }
                    break;

                case PLAYER_LEVEL.Lv3:
                    GameSpeed = -3.0f;
                    if (UnkoScore < 4)
                    {
                        ChangeLv2();
                    }
                    else if (6 <= UnkoScore)
                    {
                        ChangeLv4();
                    }
                    break;
                case PLAYER_LEVEL.Lv4:
                    GameSpeed = -3.5f;
                    if (UnkoScore < 6)
                    {
                        ChangeLv3();
                    }
                    else if (8 <= UnkoScore)
                    {
                        ChangeLv5();
                    }
                    break;
                case PLAYER_LEVEL.Lv5:
                    GameSpeed = -4.0f;
                    if (UnkoScore < 8)
                    {
                        ChangeLv4();
                    }
                    break;
            }
        }

        private void ChangeGameOver()
        {
            this.animator.SetInteger("Level", 0);
            GameSpeed = 0;
            sound.Stop();
            gameOver.SetActive(true);
            GameMode = GAMEMODE.GAMEOVER;
        }

        private void ChangeLv1()
        {
            this.animator.SetInteger("Level", 1);
            collider2d.radius = 0.25f;
            playerLevel = PLAYER_LEVEL.Lv1;
        }

        private void ChangeLv2()
        {
            this.animator.SetInteger("Level", 2);
            collider2d.radius = 0.3f;
            playerLevel = PLAYER_LEVEL.Lv2;
        }

        private void ChangeLv3()
        {
            this.animator.SetInteger("Level", 3);
            collider2d.radius = 0.375f;
            playerLevel = PLAYER_LEVEL.Lv3;
        }

        private void ChangeLv4()
        {
            this.animator.SetInteger("Level", 4);
            collider2d.radius = 0.42f;
            playerLevel = PLAYER_LEVEL.Lv4;
        }

        private void ChangeLv5()
        {
            this.animator.SetInteger("Level", 5);
            collider2d.radius = 0.5f;
            playerLevel = PLAYER_LEVEL.Lv5;
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
                    UnkoScore -= 5;
                    break;
                //サボテンに当たったときの処理
                case "Cactus":
                    //ペナルティ
                    UnkoScore -= 2;
                    break;
                //ゴールしたとき？の処理
                case "Goal":
                    ChangeClear();
                    StartCoroutine(GoClearScene());
                    break;
                default:
                    break;
            }
        }

        //GAMEMODE.GAMEOVERで呼び出される
        private void GameOver()
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        //ゴールしたときに呼び出す
        private void ChangeClear()
        {
            rigidbody.velocity = new Vector2(0, 0);
            GameSpeed = 0;
            sound.Stop();
            GameMode = GAMEMODE.CLEAR;
        }

        //GAMEMODE.CLEARで呼び出される
        private void Clear()
        {

        }

        private IEnumerator GoClearScene()
        {
            clear.SetActive(true);
            HighScoreManager.AddScore(new Score(UnkoScore, timeScore));
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("ClearScene");
        }

    }
}
