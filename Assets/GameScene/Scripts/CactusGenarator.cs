using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class CactusGenarator : MonoBehaviour
    {
        //CactusControllerコンポーネントを持たないprefabが入れられないようになる
        [SerializeField]
        private CactusController cactusPrefab = null;
        [SerializeField]
        private BigCactusController bigCactusPrefab = null;
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
        }

        //新しいサボテンを生成する部分
        public void Genarate(float x,float y,int type=0)
        {
            Genarate(new Vector3(x, y, 0),type);
        }
        public void Genarate(Vector3 pos,int type=0)
        {
            //Prefabからインスタンスを生成
            if (type==0)
            {
                CactusController genarate = Instantiate(cactusPrefab);
                genarate.transform.position = pos;
                //新しいインスタンスにPlayerとPlayerControllerをセット
                genarate.player = player;
                genarate.playerController = playerController;
            }
            else if(type==1)
            {
                BigCactusController genarate = Instantiate(bigCactusPrefab);
                genarate.transform.position = pos;
                //新しいインスタンスにPlayerとPlayerControllerをセット
                genarate.player = player;
                genarate.playerController = playerController;
            }
        }
    }
}