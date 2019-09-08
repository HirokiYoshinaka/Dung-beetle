using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class GoalGenarator : MonoBehaviour
    {
        //GoalControllerコンポーネントを持たないprefabが入れられないようになる
        [SerializeField]
        private GoalController goalPrefab = null;
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
        }

        //新しい巣穴を生成する部分
        public void Genarate(float x, float y)
        {
            Genarate(new Vector3(x, y, 0));
        }
        public void Genarate(Vector3 pos)
        {
            //Prefabからインスタンスを生成
            GoalController genarate = Instantiate(goalPrefab);
            genarate.transform.position = pos;
            //新しいインスタンスにPlayerとPlayerControllerをセット
            genarate.player = player;
            genarate.playerController = playerController;
        }
    }
}
