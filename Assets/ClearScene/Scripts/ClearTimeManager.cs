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
        private AudioSource audioSource = null;
        [SerializeField]
        private AudioClip count = null;
        [SerializeField]
        private AudioClip end = null;
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

        }

        private IEnumerator dispScore()
        {
            float time = GameScene.PlayerController.GetTimeScore();
            time = Mathf.Round(time * 10) / 10;
            float t = 0;

            while (t < time)
            {
                yield return null;
                text.text = String.Format("{0:0.0}", t);
                t += time / 60;
                audioSource.PlayOneShot(count);
            }
            yield return null;
            text.text = String.Format("{0:0.0}", time);
            audioSource.PlayOneShot(end);
        }
    }
}