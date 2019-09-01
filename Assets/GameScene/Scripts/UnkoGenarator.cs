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
            //レベルデザイン？
            switch(playerController.GetPlayerLevel())
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
            if(this.delta>this.span)
            {
                this.delta = 0;
                GenarateUnko();
            }
        }

        //新しいうんこを生成する部分
        private void GenarateUnko()
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