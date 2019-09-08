using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hunkoro
{
    /// <summary>
    ///クリックでタイトルに戻ります。
    /// </summary>
    public class GiveUpButtonController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource = null;
        [SerializeField]
        private AudioClip sound = null;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnMouseEnter()
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        private void OnMouseExit()
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        private void OnMouseDown()
        {
            StartCoroutine(LoadTitleScene());
        }

        private IEnumerator LoadTitleScene()
        {
            transform.localScale = new Vector3(1, 1, 1);
            audioSource.PlayOneShot(sound);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("TitleScene");

        }
    }
}
