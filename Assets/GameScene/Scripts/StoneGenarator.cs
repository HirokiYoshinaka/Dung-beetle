using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class StoneGenarator : MonoBehaviour
    {
        //StoneControllerコンポーネントを持たないprefabが入れられないようになる
        [SerializeField]
        private StoneController stonePrefab = null;
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
        }

        //新しい石を生成する部分
        public void Genarate(float x, float y)
        {
            Genarate(new Vector3(x, y, 0));
        }
        public void Genarate(Vector3 pos)
        {
            //Prefabからインスタンスを生成
            StoneController genarate = Instantiate(stonePrefab);
            genarate.transform.position = pos;
            //新しいインスタンスにPlayerとPlayerControllerをセット
            genarate.player = player;
            genarate.playerController = playerController;
        }
    }
}