using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Hunkoro
{
    public class ClearTimeManager : MonoBehaviour
    {
        private Text text = null;
        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            float time = PlayerController.GetTimeScore();
            time = Mathf.Round(time * 10) / 10;
            text.text = String.Format("{0:0.0}", time);
        }
    }
}