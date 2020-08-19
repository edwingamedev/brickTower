using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameObjectPool
    {
        private List<GameObject> objectPool = new List<GameObject>();
        private Transform parentObject;
        private GameObject goPrefab;
        private int poolSize;

        public GameObjectPool(Transform poolHolder, GameObject goPrefab, int poolSize)
        {
            this.parentObject = poolHolder;
            this.goPrefab = goPrefab;

            CreatePool(poolSize);
        }

        public void CreatePool(int amount)
        {
            poolSize = 0;

            for (int i = 0; i < amount; i++)
            {
                // Add to the pool
                AddToThePool();
            }
        }

        private void AddToThePool()
        {
            // Create a new instance
            GameObject obj =  Object.Instantiate(goPrefab, parentObject);

            // Add to the pool
            objectPool.Add(obj);

            // Disable it
            objectPool[poolSize].SetActive(false);

            // Increase the size number
            poolSize++;
        }

        public GameObject ExtendPool()
        {
            // Add to the pool
            AddToThePool();

            // Get last object of the pool
            return objectPool[poolSize - 1];
        }

        public GameObject GetFromPool()
        {
            for (int i = 0; i < objectPool.Count; i++)
            {
                //check if the object is disabled in the hierarchy
                if (!objectPool[i].activeInHierarchy)
                {
                    //set it to active
                    objectPool[i].SetActive(true);

                    return objectPool[i];
                }
            }

            // No available object found, extend the pool
            return ExtendPool();
        }
    }
}