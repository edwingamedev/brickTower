using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Collections.Generic;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameContainer")]
    public class GameContainer : ScriptableObject
    {
        public float blockDropRate;
        public List<Block> blocksOfSession = new List<Block>();
        private Block currentPlayingBlock => blocksOfSession.Last();

        public void RemoveBlock(Block b)
        {
            blocksOfSession.Remove(b);
            Destroy(b.gameObject);
        }

        public void RotateBlock()
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.Rotate();
        }

        public void MoveBlock(Vector2Int movement)
        {
            if (blocksOfSession.Any())
                currentPlayingBlock?.MoveBlock(movement);
        }
    }
}