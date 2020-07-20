using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class KillZone : MonoBehaviour
    {
        public GameContainer gameContainer;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Block b = collision.GetComponent<Block>();

            gameContainer.RemoveBlock(b);
        }
    }
}