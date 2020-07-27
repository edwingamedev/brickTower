using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace EdwinGameDev
{
    public class BlockGridDisplay : MonoBehaviour
    {
        public BlockData blockData;
        public GameData gameData;
        public Image[] blocksprites;
        private Sprite currentBlockSprite;

        public void SetBlock()
        {
            currentBlockSprite = blockData.GetSprite(gameData.nextBlock);

            foreach (Image blocksprite in blocksprites)
            {
                blocksprite.sprite = currentBlockSprite;
            }

            SetBlockVisual(gameData.nextBlock);

        }

        private void SetBlockVisual(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.S:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = true; blocksprites[6].enabled = true; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = true; blocksprites[9].enabled = true; blocksprites[10].enabled = false; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = false; blocksprites[14].enabled = false; blocksprites[15].enabled = false;
                    break;
                case BlockType.Z:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = true; blocksprites[5].enabled = true; blocksprites[6].enabled = false; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = true; blocksprites[10].enabled = true; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = false; blocksprites[14].enabled = false; blocksprites[15].enabled = false;
                    break;
                case BlockType.L:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = true; blocksprites[6].enabled = false; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = true; blocksprites[10].enabled = false; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = true; blocksprites[14].enabled = true; blocksprites[15].enabled = false;
                    break;
                case BlockType.J:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = false; blocksprites[6].enabled = true; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = false; blocksprites[10].enabled = true; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = true; blocksprites[14].enabled = true; blocksprites[15].enabled = false;
                    break;
                case BlockType.T:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = false; blocksprites[6].enabled = false; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = true; blocksprites[10].enabled = false; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = true; blocksprites[13].enabled = true; blocksprites[14].enabled = true; blocksprites[15].enabled = false;
                    break;
                case BlockType.O:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = false; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = true; blocksprites[6].enabled = true; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = true; blocksprites[10].enabled = true; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = false; blocksprites[14].enabled = false; blocksprites[15].enabled = false;
                    break;
                case BlockType.I:
                    blocksprites[0].enabled = false; blocksprites[1].enabled = true; blocksprites[2].enabled = false; blocksprites[3].enabled = false;
                    blocksprites[4].enabled = false; blocksprites[5].enabled = true; blocksprites[6].enabled = false; blocksprites[7].enabled = false;
                    blocksprites[8].enabled = false; blocksprites[9].enabled = true; blocksprites[10].enabled = false; blocksprites[11].enabled = false;
                    blocksprites[12].enabled = false; blocksprites[13].enabled = true; blocksprites[14].enabled = false; blocksprites[15].enabled = false;
                    break;
                default:
                    break;
            }
        }
    }
}