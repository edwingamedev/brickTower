using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Collections.Generic;

namespace EdwinGameDev
{
    [Serializable]
    public struct BlockCommands
    {
        public ScriptableEvent moveLeft;
        public ScriptableEvent moveRight;
        public ScriptableEvent moveDown;
        public ScriptableEvent turnBlock;
    }

    [CreateAssetMenu(menuName = "Edwin Game Dev/GameContainer")]
    public class GameContainer : ScriptableObject
    {
        public List<Block> blocksOfSession = new List<Block>();
        public Block currentPlayingBlock => blocksOfSession.Last();

        public BlockCommands blockCommands;

        private void OnEnable()
        {
            blockCommands.moveLeft.OnTriggered += BlockMoveLeft;
            blockCommands.moveRight.OnTriggered += BlockMoveRight;
            blockCommands.moveDown.OnTriggered += BlockMoveDown;
            blockCommands.turnBlock.OnTriggered += BlockTurn;
        }

        private void OnDisable()
        {
            blockCommands.moveLeft.OnTriggered -= BlockMoveLeft;
            blockCommands.moveRight.OnTriggered -= BlockMoveRight;
            blockCommands.moveDown.OnTriggered -= BlockMoveDown;
            blockCommands.turnBlock.OnTriggered -= BlockTurn;
        }

        public void RemoveBlock(Block b)
        {
            blocksOfSession.Remove(b);
            Destroy(b.gameObject);
        }

        public void BlockMoveLeft()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.MoveLeft();
        }

        public void BlockMoveRight()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.MoveRight();
        }

        public void BlockMoveDown()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.MoveDown();
        }

        public void BlockTurn()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.RotateLeft();
        }
    }
}