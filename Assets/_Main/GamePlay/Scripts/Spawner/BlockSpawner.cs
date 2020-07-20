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
            GameObject blockGO = Instantiate(blockFactory.GetRandomBlock(), spawnPoint.position, Quaternion.identity, spawnPoint);
            Block block = blockGO.GetComponent<Block>();
            gameContainer.blocksOfSession.Add(block);
        }
    }
}