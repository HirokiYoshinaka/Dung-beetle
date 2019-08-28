using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hunkoro
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController = null;
        private Text text;
        // Start is called before the first frame update
        void Start()
        {
            this.text = GetComponent<Text>();
            playerController = player.GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            text.text = "集めたうんこ：" + playerController.GetUnkoScore();
        }
    }
}