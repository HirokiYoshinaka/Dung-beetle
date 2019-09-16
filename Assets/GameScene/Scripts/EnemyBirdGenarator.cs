using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    namespace GameScene
    {
        /// <summary>
        /// "ハゲワシ"の生成管理
        /// </summary>
        public class EnemyBirdGenarator : MonoBehaviour
        {
            [SerializeField]
            private EnemyBirdController enemyBirdPrefab = null;
            [SerializeField]
            private GameObject player = null;
            private PlayerController playerController;
            [SerializeField]
            private int spanCount = 0;
            // Start is called before the first frame update
            void Start()
            {
                playerController = player.GetComponent<PlayerController>();
            }

            private void Update()
            {
                if (playerController.GetGameMode() == GAMEMODE.PLAY)
                {
                    switch (playerController.GetPlayerLevel())
                    {
                        case PLAYER_LEVEL.Lv1:
                        case PLAYER_LEVEL.Lv2:
                            spanCount++;
                            break;
                        case PLAYER_LEVEL.Lv3:
                        case PLAYER_LEVEL.Lv4:
                            spanCount += 2;
                            break;
                        case PLAYER_LEVEL.Lv5:
                            spanCount += 3;
                            break;
                    }
                }
                if(spanCount>1200)
                {
                    spanCount = 0;
                    Genarate();
                }
            }

            //新しいインスタンスを生成する部分
            //ランダム生成に変更
            private void Genarate()
            {
                //PrefabからGameObjectを生成
                EnemyBirdController genarate = Instantiate(enemyBirdPrefab);
                genarate.transform.position 
                    = new Vector3(Random.Range(-3.5f, 3.5f), -4, 0);
                //新しいインスタンスにPlayerとPlay
                genarate.player = playerController;
            }
        }
    }
}