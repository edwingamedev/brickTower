using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/Data/BlockData")]
    public class BlockData : ScriptableObject
    {
        private BlockStructure blockStructure = new BlockStructure();
        public GameObject piecePrefab;
        public Sprite[] blockSprites;

        public Piece[] GetBlockPieces(Vector2Int spawnPos, BlockType blockType, Transform parent)
        {
            return blockStructure.GetPieces(piecePrefab, spawnPos, blockType, parent, GetSprite(blockType));
        }

        public Vector2Int[,] GetOffSet(BlockType blockType)
        {
            return blockStructure.GetBlockOffset(blockType);
        }

        public Sprite GetSprite(BlockType blockType)
        {
            if (blockSprites == null)
                return null;

            int index = blockSprites.Length;

            switch (blockType)
            {
                case BlockType.S:
                    return blockSprites[0 % index];
                case BlockType.Z:
                    return blockSprites[1 % index];
                case BlockType.L:
                    return blockSprites[2 % index];
                case BlockType.J:
                    return blockSprites[3 % index];
                case BlockType.T:
                    return blockSprites[4 % index];
                case BlockType.O:
                    return blockSprites[5 % index];
                case BlockType.I:
                    return blockSprites[6 % index];
                default:
                    return blockSprites[0 % index];
            }
        }
    }
}