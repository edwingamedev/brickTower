using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameContainer")]
    public class GameContainer : ScriptableObject
    {
        public BlockMovement blockMovement;
        public float blockDropRate;
        private List<Block> blocksOfSession = new List<Block>();
        private Block currentPlayingBlock => blocksOfSession.Last();
        private bool paused = true;
        public int towerHeight = 0;
        public BlockType nextBlock;

        public void SetPause(bool paused)
        {
            this.paused = paused;

            if (paused)
            {
                foreach (Block block in blocksOfSession)
                {
                    block.DisablePhysics();
                }
            }
            else
            {
                foreach (Block block in blocksOfSession)
                {
                    block.ResumePhysics();
                }
            }
        }

        public void NextBlock(BlockType nextBlock)
        {
            this.nextBlock = nextBlock;
        }

        public void RemoveLastBlock()
        {
            Block b = blocksOfSession[blocksOfSession.Count - 2];

            RemoveBlock(b);
        }

        public void RemoveBlock(Block b)
        {
            if (b)
            {
                blocksOfSession.Remove(b);

                if (b.gameObject)
                    Destroy(b.gameObject);
            }
        }

        public void ResetGame()
        {
            for (int i = blocksOfSession.Count - 1; i >= 0; i--)
            {
                RemoveBlock(blocksOfSession[i]);
            }

            blocksOfSession.Clear();
            towerHeight = 0;
        }

        public void AddBlock(Block block)
        {
            blocksOfSession.Add(block);
        }

        public void RotateBlock()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.Rotate();
        }

        public void MoveBlock(MovementType movementType)
        {
            if (paused)
                return;

            if (blocksOfSession.Any())
            {
                switch (movementType)
                {
                    default:
                    case MovementType.Down:
                        currentPlayingBlock.MoveBlock(new Vector2(0, -blockMovement.vertical));
                        break;
                    case MovementType.Left:
                        currentPlayingBlock.MoveBlock(new Vector2(-blockMovement.horizontal, 0));
                        break;
                    case MovementType.Right:
                        currentPlayingBlock.MoveBlock(new Vector2(blockMovement.horizontal, 0));
                        break;
                }
            }
        }

        public bool CheckTowerHeight()
        {
            if (blocksOfSession[blocksOfSession.Count - 1].GetHighestPiecePosition() > towerHeight + 5)
            {
                towerHeight += 2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}