using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public enum FieldPattern
    {

    }

    public class GenarateManager : MonoBehaviour
    {
        private new Rigidbody2D rigidbody;
        [SerializeField]
        private PlayerController player = null;
        [SerializeField]
        private UnkoGenarator unko = null;
        [SerializeField]
        private StoneGenarator stone = null;
        [SerializeField]
        private CactusGenarator cactus = null;
        [SerializeField]
        private GoalGenarator goal = null;
        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rigidbody.velocity = new Vector2(0, player.GetSpeed());
            //このGenaratorを一緒に動かすことで生成間隔を同期（？）する
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(0, transform.position.y + 10, 0);
                GenarateField_1();
            }
        }

        //生成するフィールドを決定する
        void ChooseField()
        {

        }

        void GenarateField_1()
        {
            unko.Genarate(new Vector3(-2.5f, 13f));
            unko.Genarate(new Vector3(-2.5f, 6.5f));
            unko.Genarate(new Vector3(-0.5f, 7.5f));
            unko.Genarate(new Vector3(-0.5f, 10.5f));
            unko.Genarate(new Vector3(0.5f, 13.5f));
            unko.Genarate(new Vector3(1.5f, 9f));
            unko.Genarate(new Vector3(2f, 15f));
            stone.Genarate(new Vector3(-2f, 8.5f));
            stone.Genarate(new Vector3(2f, 13f));
            cactus.Genarate(new Vector3(-1.5f, 15f));
            cactus.Genarate(new Vector3(-1f, 12.5f));
            goal.Genarate(new Vector3(2.5f, 8f));
        }
    }
}