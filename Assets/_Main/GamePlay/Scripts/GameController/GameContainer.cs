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
        private List<Block> disabledBlocks = new List<Block>();
        private Block currentPlayingBlock => blocksOfSession.Last();
        private bool paused = true;
        public int towerHeight = 0;
        public BlockType nextBlock;
        public Transform heightBlock;

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

        public void DisableBlock(Block block)
        {
            block.DisableBlock();

            blocksOfSession.Remove(block);
            disabledBlocks.Add(block);
        }

        public void RemoveFallenBlocks()
        {
            List<Block> fallenBlocks = blocksOfSession.Where(b => b.fellOff).ToList();

            foreach (Block fallenBlock in fallenBlocks)
            {
                RemoveBlock(fallenBlock, blocksOfSession);
            }

            //Block b = blocksOfSession[blocksOfSession.Count - 2];

            //RemoveBlock(b, blocksOfSession);
        }

        public void RemoveBlock(Block b, List<Block> listOfBlocks)
        {
            if (b)
            {
                listOfBlocks.Remove(b);

                if (b.gameObject)
                    Destroy(b.gameObject);
            }
        }

        public void ResetGame()
        {
            for (int i = blocksOfSession.Count - 1; i >= 0; i--)
            {
                RemoveBlock(blocksOfSession[i], blocksOfSession);
            }

            for (int i = disabledBlocks.Count - 1; i >= 0; i--)
            {
                RemoveBlock(blocksOfSession[i], disabledBlocks);
            }

            blocksOfSession.Clear();
            towerHeight = 0;
            heightBlock = null;
        }

        public void AddBlock(Block block)
        {
            blocksOfSession.Add(block);
        }

        public void RotateBlock()
        {
            if (paused)
                return;

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

        public Transform GetHighestBlock()
        {
            // No Highest yet
            if (heightBlock == null)
            {
                if (blocksOfSession.Any())
                    heightBlock = blocksOfSession[blocksOfSession.Count - 1].GetHighestPiecePosition().transform;
            }
            else
            {
                Transform lastPlaceBlock = blocksOfSession[blocksOfSession.Count - 1].GetHighestPiecePosition().transform;

                if (lastPlaceBlock.position.y > heightBlock.position.y)
                {
                    heightBlock = lastPlaceBlock;
                }
                else
                {
                    Block block = blocksOfSession.FirstOrDefault(x => x.GetHighestPiecePosition().transform.position.y > heightBlock.position.y);

                    if (block)
                        heightBlock = block.higherPiece.transform;
                }
            }

            return heightBlock;
        }
    }
}