using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hunkoro
{
    namespace GameScene
    {
        /// <summary>
        /// スコアの表示を行います
        /// </summary>
        public class ScoreManager : MonoBehaviour
        {
            private Text text;
            // Start is called before the first frame update
            void Start()
            {
                this.text = GetComponent<Text>();
            }

            // Update is called once per frame
            void Update()
            {
                text.text = "あつめたうんこ：" + PlayerController.GetUnkoScore().ToString();
            }
        }
    }
}