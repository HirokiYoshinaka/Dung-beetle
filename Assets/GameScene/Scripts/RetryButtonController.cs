using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hunkoro
{
    /// <summary>
    ///クリックでシーンをリロードします。
    /// </summary>
    public class RetryButtonController : MonoBehaviour
    {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}