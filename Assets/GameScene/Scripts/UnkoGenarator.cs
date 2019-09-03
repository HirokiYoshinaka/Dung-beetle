using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class UnkoGenarator : MonoBehaviour
    {
        //UnkoController型とする
        //UnkoControllerコンポーネントを持たないprefabが入れられないようになる
        [SerializeField]
        private UnkoController unkoPrefab = null;
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
                    case PLAYER_LEVEL.Lv1:
                        span = 2;
                        break;
                    case PLAYER_LEVEL.Lv2:
                        break;
                    case PLAYER_LEVEL.Lv3:
                        break;
                    case PLAYER_LEVEL.Lv4:
                        break;
                    case PLAYER_LEVEL.Lv5:
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

        //新しいうんこを生成する部分
        private void Genarate()
        {
            //PrefabからGameObjectを生成
            UnkoController genarate = Instantiate(unkoPrefab);
            genarate.transform.position = new Vector3(0, 5, 0);
            //新しいうんこにPlayerとPlay
            genarate.player = player;
            genarate.playerController = playerController;
        }
    }
}