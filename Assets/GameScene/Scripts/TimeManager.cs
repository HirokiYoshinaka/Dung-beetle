using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Hunkoro
{
    namespace GameScene
    {
        /// <summary>
        /// 時間の表示を行います
        /// </summary>
        public class TimeManager : MonoBehaviour
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
                float time = PlayerController.GetTimeScore();
                //小数点一桁への切り上げ
                time = Mathf.Round(time * 10) / 10;
                //文字列の書式設定、Google検索は偉大
                text.text = String.Format("せいぞんじかん：{0:0.0}びょう", time); ;
            }
        }
    }
}