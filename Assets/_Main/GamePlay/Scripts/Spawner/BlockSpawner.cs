using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class BlockSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public Transform blockHolder;
        public BlockFactory blockFactory;
        public GameContainer gameContainer;
        private BlockType nextBlock;

        private void Awake()
        {
            nextBlock = blockFactory.GenerateRandomBlockType();
        }

        public void SpawnRandomBlock()
        {
            Block block = blockFactory.SpawnBlock(nextBlock, spawnPoint, blockHolder);
            gameContainer.AddBlock(block);            

            nextBlock = blockFactory.GenerateRandomBlockType();
            gameContainer.NextBlock(nextBlock);
        }
    }
}