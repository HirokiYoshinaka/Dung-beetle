using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunkoro
{
    public class UnkoGenarator : MonoBehaviour
    {
        [SerializeField]
        private GameObject unkoPrefab = null;
        [SerializeField]
        private GameObject player = null;
        private PlayerController playerController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = player.GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            switch(playerController.GetPlayerLevel())
            {
                case PLAYER_LEVEL.FIRST:
                    break;
                case PLAYER_LEVEL.SECOND:
                    break;
                case PLAYER_LEVEL.THIRD:
                    break;
                case PLAYER_LEVEL.FORTH:
                    break;
                case PLAYER_LEVEL.FIFTH:
                    break;
            }
        }
    }
}