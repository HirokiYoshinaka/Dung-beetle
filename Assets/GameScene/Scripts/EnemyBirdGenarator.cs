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

            // Start is called before the first frame update
            void Start()
            {
                playerController = player.GetComponent<PlayerController>();
            }

            //新しいインスタンスを生成する部分
            public void Genarate(float x, float y)
            {
                Genarate(new Vector3(x, y, 0));
            }
            public void Genarate(Vector3 pos)
            {
                //PrefabからGameObjectを生成
                EnemyBirdController genarate = Instantiate(enemyBirdPrefab);
                genarate.transform.position = pos;
                //新しいインスタンスにPlayerとPlay
                genarate.player = player;
                genarate.playerController = playerController;
            }
        }
    }
}