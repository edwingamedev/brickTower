using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public class BlockController : MonoBehaviour
    {
        public GameContainer gameContainer;
        public BlockCommands blockCommands;
        private float currentDropTick;
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

        private void FixedUpdate()
        {
            DropBlock();
        }

        private void DropBlock()
        {
            if (Time.time > currentDropTick)
            {
                BlockMoveDown();
                currentDropTick = Time.time + gameContainer.blockDropRate;
            }
        }

        public void BlockFellOff()
        {
            gameContainer?.RemoveLastBlock();
        }

        public void BlockMoveLeft()
        {
            gameContainer?.MoveBlock(MovementType.Left);
        }

        public void BlockMoveRight()
        {
            gameContainer?.MoveBlock(MovementType.Right);
        }

        public void BlockMoveDown()
        {
            gameContainer?.MoveBlock(MovementType.Down);
        }

        public void BlockTurn()
        {
            gameContainer?.RotateBlock();
        }
    }
}