using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/BlockContainer")]
    public class BlockFactory : ScriptableObject
    {
        public List<GameObject> blocks;

        public GameObject GetRandomBlock()
        {
            return blocks[Random.Range(0, blocks.Count - 1)];
        }
    }
}