using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hunkoro
{
    public class ClearScoreManager : MonoBehaviour
    {
        private Text text = null;
        private AudioSource audioSource = null;
        [SerializeField]
        private AudioClip audioClip = null;
        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<Text>();
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(dispScore());
        }

        // Update is called once per frame
        void Update()
        {

            //text.text = PlayerController.GetUnkoScore().ToString();
        }

        private IEnumerator dispScore()
        {
            int s = 0;
            while (s < GameScene.PlayerController.GetUnkoScore())
            {
                yield return new WaitForSeconds(0.1f);
                s++;
                text.text = s.ToString();
                audioSource.PlayOneShot(audioClip);
            }
            GameObject next = transform.Find("Time").gameObject;
            next.SetActive(true);
        }
    }
}