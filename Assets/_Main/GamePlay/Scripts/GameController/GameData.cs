using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

namespace EdwinGameDev
{    
    [CreateAssetMenu(menuName = "Edwin Game Dev/Data/Game Data")]
    public class GameData : ScriptableObject
    {
        public int numOfLives;
        public int heightToWin;
        public BlockMovement blockMovement;
        public float blockDropRate;
        private List<Block> blocksOfSession = new List<Block>();
        private List<Block> disabledBlocks = new List<Block>();
        private Block currentPlayingBlock => blocksOfSession.Last();
        private bool paused = true;
        public int towerHeight = 0;
        [HideInInspector]
        public BlockType nextBlock;
        private Transform highestBlock;        

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

        public void DisableBlockBelow(int disablePosition)
        {
            //Debug.Log("disabling blocks below: " + disablePosition);

            for (int i = blocksOfSession.Count - 1; i >= 0; i--)
            {
                if (blocksOfSession[i].placed && blocksOfSession[i].GetHighestPiecePosition().transform.position.y < disablePosition)
                {
                    DisableBlock(blocksOfSession[i]);
                }
            }
        }

        public void DisableBlock(Block block)
        {
            if (!block.DisableBlock())
                return;

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
            if (blocksOfSession.Any())
            {
                for (int i = blocksOfSession.Count - 1; i >= 0; i--)
                {
                    RemoveBlock(blocksOfSession[i], blocksOfSession);
                }
            }

            if (disabledBlocks.Any())
            {
                for (int i = disabledBlocks.Count - 1; i >= 0; i--)
                {
                    RemoveBlock(disabledBlocks[i], disabledBlocks);
                }
            }

            blocksOfSession.Clear();
            towerHeight = 0;
            highestBlock = null;
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

        public int GetHighestBlock()
        {
            // No Highest yet
            if (highestBlock == null)
            {
                if (blocksOfSession.Any())
                    highestBlock = blocksOfSession.FirstOrDefault(b => b.placed).GetHighestPiecePosition().transform;
            }
            else
            {
                float higherPos = 0;
                Transform higherBlock = null;

                for (int i = 0; i < blocksOfSession.Count; i++)
                {
                    if (blocksOfSession[i].placed && blocksOfSession[i].GetHighestPiecePosition().transform.position.y > higherPos)
                    {
                        higherBlock = blocksOfSession[i].GetHighestPiecePosition().transform;
                        higherPos = higherBlock.position.y;
                    }
                }

                if (higherBlock)
                {
                    highestBlock = higherBlock;
                }
            }

            towerHeight = Mathf.CeilToInt(highestBlock.position.y) - 5;

            return towerHeight;
        }
    }
}