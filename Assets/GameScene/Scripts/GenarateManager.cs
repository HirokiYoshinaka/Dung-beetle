using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    namespace GameScene
    {
        /// <summary>
        /// フィールド生成の設定を行います。
        /// </summary>
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

            [SerializeField]
            private int pattern = 0;
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
                    ChooseField();
                }
            }

            //フィールドを決定して生成する
            void ChooseField()
            {
                //patternを０に戻さずループすることでレアなフィールドの出現などが簡単に実装できそう
                switch (pattern % 10)
                //switch (Random.Range(0, 9))
                {
                    case 0:
                        GenarateField_1();
                        break;
                    case 1:
                        GenarateField_2();
                        break;
                    case 2:
                        GenarateField_3();
                        break;
                    case 3:
                        GenarateField_4();
                        break;
                    case 4:
                        GenerateField_5();
                        break;
                    case 5:
                        GenarateField_6();
                        break;
                    case 6:
                        GenarateField_7();
                        break;
                    case 7:
                        GenarateField_8();
                        break;
                    case 8:
                        GenarateField_9();
                        break;
                    case 9:
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                GenarateField_1();
                                break;
                            case 1:
                                GenarateField_2();
                                break;
                            case 2:
                                GenarateField_3();
                                break;
                            case 3:
                                GenarateField_4();
                                break;
                            case 4:
                                GenerateField_5();
                                break;
                            case 5:
                                GenarateField_6();
                                break;
                            case 6:
                                GenarateField_7();
                                break;
                            case 7:
                                GenarateField_8();
                                break;
                            case 8:
                                GenarateField_9();
                                break;
                        }
                        break;
                }
                pattern++;
            }

            void GenarateField_1()
            {
                unko.Genarate(-2.5f, 13f);
                unko.Genarate(-2.5f, 6.5f);
                unko.Genarate(-0.5f, 7.5f);
                unko.Genarate(-0.5f, 10.5f);
                unko.Genarate(0.5f, 13.5f);
                unko.Genarate(1.5f, 9f);
                unko.Genarate(2f, 15f);

                stone.Genarate(-2f, 8.5f);
                stone.Genarate(2f, 13f);

                cactus.Genarate(-1.5f, 15f, 1);
                cactus.Genarate(-1f, 12.5f);
                goal.Genarate(2.5f, 8f);
            }

            void GenarateField_2()
            {
                unko.Genarate(-2f, 8f);
                unko.Genarate(-2f, 14f);
                unko.Genarate(0f, 13.5f);
                unko.Genarate(0f, 11f);
                unko.Genarate(0f, 7f);
                unko.Genarate(1.5f, 14.5f);
                unko.Genarate(1.5f, 8.5f);
                unko.Genarate(3f, 12.5f);
                stone.Genarate(0f, 9.5f);

                cactus.Genarate(-3f, 7f);
                cactus.Genarate(-1.5f, 12f);

                goal.Genarate(-2.5f, 10.5f);
                goal.Genarate(3.5f, 14.5f);
            }

            void GenarateField_3()
            {
                unko.Genarate(-2.5f, 7f);
                unko.Genarate(-2.5f, 12f);
                unko.Genarate(-1f, 10.5f);
                unko.Genarate(-1f, 14f);
                unko.Genarate(0.5f, 9f);
                unko.Genarate(0.5f, 15f);
                unko.Genarate(2f, 7.5f);
                unko.Genarate(2f, 12f);
                unko.Genarate(3, 15f);

                cactus.Genarate(-2.5f, 15f);
                cactus.Genarate(-2f, 9.5f, 1);
                cactus.Genarate(0.5f, 12f);
            }

            void GenarateField_4()
            {
                unko.Genarate(0f, 10.5f);
                unko.Genarate(1.5f, 15f);
                unko.Genarate(1.5f, 7.5f);

                cactus.Genarate(-3.5f, 14.5f);
                cactus.Genarate(-2.5f, 11f, 1);
                cactus.Genarate(-2.5f, 17.5f);
                cactus.Genarate(-1f, 13.5f);
                cactus.Genarate(0f, 15f, 1);
                cactus.Genarate(0f, 8f);
                cactus.Genarate(1f, 12f);
                cactus.Genarate(2.5f, 8.5f, 1);
                cactus.Genarate(3.5f, 13.5f);
            }

            void GenerateField_5()
            {
                unko.Genarate(-3f, 11f);
                unko.Genarate(-2f, 12f);
                unko.Genarate(-2f, 10f);
                unko.Genarate(-2f, 6f);
                unko.Genarate(-1f, 13f);
                unko.Genarate(-1f, 9f);
                unko.Genarate(-1f, 7f);
                unko.Genarate(0f, 14f);
                unko.Genarate(0f, 11f);
                unko.Genarate(0f, 18f);
                unko.Genarate(1f, 13f);
                unko.Genarate(1f, 9f);
                unko.Genarate(1f, 7f);
                unko.Genarate(2f, 12f);
                unko.Genarate(2f, 10f);
                unko.Genarate(2f, 6f);
                unko.Genarate(3f, 11f);
                stone.Genarate(-2f, 13.5f);
                goal.Genarate(-2f, 14.5f);
            }

            void GenarateField_6()
            {
                unko.Genarate(-2f, 12f);
                unko.Genarate(-2f, 7f);
                unko.Genarate(-1.5f, 9f);
                unko.Genarate(0.5f, 15f);
                unko.Genarate(0.5f, 13f);
                unko.Genarate(1.5f, 11f);
                unko.Genarate(2.5f, 8.5f);
                unko.Genarate(3.5f, 14.5f);
                stone.Genarate(0f, 7.5f);
                cactus.Genarate(-3f, 11.5f);
                cactus.Genarate(-2.5f, 8.5f);
                cactus.Genarate(-1f, 12.5f, 1);
                cactus.Genarate(0f, 9.5f, 1);
                cactus.Genarate(1.5f, 8.5f);
                cactus.Genarate(2f, 14.5f);
            }

            void GenarateField_7()
            {
                unko.Genarate(-3f, 10f);
                unko.Genarate(-1.5f, 6.5f);
                unko.Genarate(-1.5f, 9f);
                unko.Genarate(-1f, 10.5f);
                unko.Genarate(1f, 9.5f);
                unko.Genarate(1.5f, 7.5f);
                unko.Genarate(3f, 10f);

                stone.Genarate(-2.5f, 14f);
                stone.Genarate(0f, 14.5f);
                stone.Genarate(2.5f, 14f);

                cactus.Genarate(-2f, 9f);
                cactus.Genarate(-2f, 8.5f);
                cactus.Genarate(-2f, 8f);
                cactus.Genarate(-2f, 7.5f);
                cactus.Genarate(-2f, 7f);
                cactus.Genarate(-2f, 6.5f);
                cactus.Genarate(-2f, 6f);

                cactus.Genarate(2f, 9f);
                cactus.Genarate(2f, 8.5f);
                cactus.Genarate(2f, 8f);
                cactus.Genarate(2f, 7.5f);
                cactus.Genarate(2f, 7f);
                cactus.Genarate(2f, 6.5f);
                cactus.Genarate(2f, 6f);

                cactus.Genarate(-1.5f, 11f);
                cactus.Genarate(-1.5f, 10.5f);
                cactus.Genarate(-1.5f, 10f);
                cactus.Genarate(-1.5f, 9.5f);

                cactus.Genarate(1.5f, 11f);
                cactus.Genarate(1.5f, 10.5f);
                cactus.Genarate(1.5f, 10f);
                cactus.Genarate(1.5f, 9.5f);

                cactus.Genarate(1f, 12f, 1);
                cactus.Genarate(1f, 11.5f, 1);
                cactus.Genarate(-1f, 12f, 1);
                cactus.Genarate(-1f, 11.5f, 1);
            }

            void GenarateField_8()
            {
                unko.Genarate(-1.5f, 10.5f);
                unko.Genarate(1.5f, 10.5f);
                unko.Genarate(-1f, 9f);
                unko.Genarate(-1f, 12f);
                unko.Genarate(1f, 9f);
                unko.Genarate(1f, 12f);
                unko.Genarate(0f, 8.5f);
                unko.Genarate(0f, 12.5f);

                stone.Genarate(0f, 10.5f);

                cactus.Genarate(2.5f, 11.5f);
                cactus.Genarate(2.5f, 9.5f);
                cactus.Genarate(-2.5f, 11.5f);
                cactus.Genarate(-2.5f, 9.5f);

                cactus.Genarate(2f, 7.5f);
                cactus.Genarate(2f, 13.5f);
                cactus.Genarate(-2f, 7.5f);
                cactus.Genarate(-2f, 13.5f);

                cactus.Genarate(1f, 6.5f, 1);
                cactus.Genarate(1f, 14.5f, 1);
                cactus.Genarate(-1f, 6.5f, 1);
                cactus.Genarate(-1f, 14.5f, 1);

                goal.Genarate(2f, 13f);
            }

            void GenarateField_9()
            {
                unko.Genarate(-2.5f, 14f);
                stone.Genarate(-2f, 14f);
                unko.Genarate(-1.5f, 14f);

                unko.Genarate(-2.5f, 7.5f);
                stone.Genarate(-2f, 7.5f);
                unko.Genarate(-1.5f, 7.5f);

                unko.Genarate(-0.5f, 11f);
                stone.Genarate(0f, 11f);
                unko.Genarate(0.5f, 11f);

                unko.Genarate(2.5f, 14f);
                stone.Genarate(2f, 14f);
                unko.Genarate(1.5f, 14f);

                unko.Genarate(2.5f, 7.5f);
                stone.Genarate(2f, 7.5f);
                unko.Genarate(1.5f, 7.5f);
            }
        }
    }
}