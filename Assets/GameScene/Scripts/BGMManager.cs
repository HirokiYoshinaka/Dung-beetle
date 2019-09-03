using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    /// <summary>
    /// BGMを制御します。Playerから呼び出し
    /// </summary>
    public class BGMManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip wind = null;
        [SerializeField]
        private AudioClip music = null;
        [SerializeField]
        private AudioSource audioSource = null;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = wind;
            audioSource.Play();
            audioSource.loop = true;
        }

        //BGMをプレイ中のものに切り替えます。
        public void StartPlayBGM()
        {
            audioSource.Stop();
            audioSource.clip = music;
            audioSource.Play();
        }
    }
}
