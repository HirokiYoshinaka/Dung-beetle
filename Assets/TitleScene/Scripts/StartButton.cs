using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hunkoro {
    public class StartButton : MonoBehaviour
    {
        //クリックしたとき
        private void OnMouseDown()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnMouseEnter()
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }

        private void OnMouseExit()
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}