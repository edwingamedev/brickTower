using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class BlockSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public BlockFactory blockFactory;
        public GameContainer gameContainer;

        public void SpawnRandomBlock()
        {
            Block block = blockFactory.SpawnRandomBlock(spawnPoint);
            gameContainer.blocksOfSession.Add(block);
        }
    }
}