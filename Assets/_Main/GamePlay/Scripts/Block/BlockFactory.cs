using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/BlockContainer")]
    public class BlockFactory : ScriptableObject
    {
        public GameSettings gameSettings;
        public GameObject blockPrefab;

        public Block SpawnBlock(BlockType blockType, Transform spawnPoint)
        {
            GameObject blockGO = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            Block block = blockGO.GetComponent<Block>();

            Vector2Int spawnPosition = new Vector2Int((int)spawnPoint.position.x, (int)spawnPoint.position.y);
            Piece[] blockPieces = GetBlockPieces(spawnPosition, blockType, blockGO.transform);

            block.Build(spawnPosition, blockType, blockPieces, gameSettings.GetOffSet(blockType));

            return block;
        }

        public Block SpawnRandomBlock(Transform spawnPoint)
        {
            int randomIndex = Random.Range(0, BlockType.GetNames(typeof(BlockType)).Length);
            return SpawnBlock((BlockType)randomIndex, spawnPoint);
        }

        private Piece[] GetBlockPieces(Vector2Int spawnPos, BlockType blockType, Transform parent)
        {
            return gameSettings.GetBlockPieces(spawnPos, blockType, parent);
        }
    }
}