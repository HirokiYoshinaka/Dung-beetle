using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    namespace GameScene
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

            // Start is called before the first frame update
            void Start()
            {
                playerController = player.GetComponent<PlayerController>();
            }

            //新しいうんこを生成する部分
            public void Genarate(float x, float y)
            {
                Genarate(new Vector3(x, y, 0));
            }
            public void Genarate(Vector3 pos)
            {
                //PrefabからGameObjectを生成
                UnkoController genarate = Instantiate(unkoPrefab);
                genarate.transform.position = pos;
                //新しいうんこにPlayerとPlay
                genarate.player = player;
                genarate.playerController = playerController;
            }
        }
    }
}