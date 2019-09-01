using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class GoalGenarator : MonoBehaviour
    {
        //StoneControllerコンポーネントを持たないprefabが入れられないようになる
        [SerializeField]
        private GoalController goalPrefab = null;
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;

        //生成間隔
        [SerializeField]
        private float span = 0;
        //間隔管理用変数
        [SerializeField]
        private float delta = 0;
        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            //PLAY中のみ生成
            if (playerController.GetGameMode() == GAMEMODE.PLAY)
            {
                //レベルデザイン？
                switch (playerController.GetPlayerLevel())
                {
                    case PLAYER_LEVEL.FIRST:
                        span = 2;
                        break;
                    case PLAYER_LEVEL.SECOND:
                        break;
                    case PLAYER_LEVEL.THIRD:
                        break;
                    case PLAYER_LEVEL.FORTH:
                        break;
                    case PLAYER_LEVEL.FIFTH:
                        break;
                }
                this.delta += Time.deltaTime;
                if (this.delta > this.span)
                {
                    this.delta = 0;
                    Genarate();
                }
            }
        }
        //新しい巣穴を生成する部分
        private void Genarate()
        {
            //Prefabからインスタンスを生成
            GoalController genarate = Instantiate(goalPrefab);
            genarate.transform.position = new Vector3(-3, 5, 0);
            //新しいインスタンスにPlayerとPlayerControllerをセット
            genarate.player = player;
            genarate.playerController = playerController;
        }
    }
}
