using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hunkoro
{
    public class ClearScoreManager : MonoBehaviour
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
            text.text = PlayerController.GetUnkoScore().ToString();
        }
    }
}