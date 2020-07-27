using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/Blocks/BlockContainer")]
    public class BlockFactory : ScriptableObject
    {
        public BlockData blockData;
        public GameObject blockPrefab;

        public Block SpawnBlock(BlockType blockType, Transform spawnPoint, Transform blockHolder)
        {
            GameObject blockGO = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity, blockHolder);
            Block block = blockGO.GetComponent<Block>();

            Vector2Int spawnPosition = new Vector2Int((int)spawnPoint.position.x, (int)spawnPoint.position.y);
            Piece[] blockPieces = GetBlockPieces(spawnPosition, blockType, blockGO.transform);

            block.Build(spawnPosition, blockType, blockPieces, blockData.GetOffSet(blockType));

            return block;
        }

        public BlockType GenerateRandomBlockType()
        {
            int randomIndex = Random.Range(0, BlockType.GetNames(typeof(BlockType)).Length);

            return (BlockType)randomIndex;
        }

        public Block SpawnRandomBlock(Transform spawnPoint, Transform blockHolder)
        {            
            return SpawnBlock(GenerateRandomBlockType(), spawnPoint, blockHolder);
        }

        private Piece[] GetBlockPieces(Vector2Int spawnPos, BlockType blockType, Transform parent)
        {
            return blockData.GetBlockPieces(spawnPos, blockType, parent);
        }
    }
}