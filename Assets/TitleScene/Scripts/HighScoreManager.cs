using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Hunkoro
{
    public class Score
    {
        public int scoreCount;
        public float time;

        public Score(int scoreCount, float time)
        {
            this.scoreCount = scoreCount;
            this.time = time;
        }
    }

    public class HighScoreManager : MonoBehaviour
    {
        public Text first_time = null;
        public Text first_Score = null;
        public Text second_time = null;
        public Text second_Score = null;
        public Text third_time = null;
        public Text third_Score = null;

        static Score[] highScores 
            = new Score[3] { new Score(0, 0), new Score(0, 0), new Score(0, 0) };

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            first_Score.text = highScores[0].scoreCount.ToString();
            first_time.text = String.Format("{0:0.0}", highScores[0].time);
            second_Score.text = highScores[1].scoreCount.ToString();
            second_time.text = String.Format("{0:0.0}", highScores[1].time);
            third_Score.text = highScores[2].scoreCount.ToString();
            third_time.text = String.Format("{0:0.0}", highScores[2].time);
        }

        //新しいスコアが３位以内なら追加する
        public static void AddScore(Score s)
        {
            //１位
            if(s.scoreCount>highScores[0].scoreCount)
            {
                highScores[2] = new Score(highScores[1].scoreCount, highScores[1].time);
                highScores[1] = new Score(highScores[0].scoreCount, highScores[0].time);
                highScores[0] = new Score(s.scoreCount, s.time);
            }
            //２位
            else if(s.scoreCount>highScores[1].scoreCount)
            {
                highScores[2] = new Score(highScores[1].scoreCount, highScores[1].time);
                highScores[1] = new Score(s.scoreCount, s.time);
            }
            //３位
            else if(s.scoreCount>highScores[2].scoreCount)
            {
                highScores[2] = new Score(s.scoreCount, s.time);
            }
        }
    }
}