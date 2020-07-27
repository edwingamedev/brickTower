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
        public GameData gameData;
        private BlockType nextBlock;

        private void Awake()
        {
            ResetGame();

            nextBlock = blockFactory.GenerateRandomBlockType();            
        }

        public void ResetGame()
        {
            gameData.ResetGame();
        }

        public void SpawnRandomBlock()
        {
            Block block = blockFactory.SpawnBlock(nextBlock, spawnPoint, blockHolder);
            gameData.AddBlock(block);            

            nextBlock = blockFactory.GenerateRandomBlockType();
            gameData.NextBlock(nextBlock);
        }
    }
}