using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    /// <summary>
    /// "Player"の挙動を指定します。
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        //移動に使うので取得
        private new Rigidbody2D rigidbody;
        //速度を指定
        [SerializeField]
        private float speed = 1.0f;


        // Start is called before the first frame update
        void Start()
        {
            //Rigidbody2dコンポーネントを取得
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //x方向の移動は変更せずにy方向に等速度運動
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed);
        }
    }
}
