using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class CloudSpawner : MonoBehaviour
    {
        public GameGrid gameGrid;
        public Sprite[] cloudSprites;
        public Color[] colors;
        private float currentMoveTick;
        public GameObject cloudPrefab;
        public List<GameObject> clouds;
        public Transform cloudHolder;


        // Update is called once per frame
        void Update()
        {
            if (Time.time > currentMoveTick)
            {
                SpawnCloud();
                currentMoveTick = Time.time + Random.Range(2,5);
            }
        }

        public void SpawnCloud()
        {
            bool dir = Random.Range(0, 2) != 0;

            Vector3 spawnPos = dir ? new Vector3(gameGrid.gridMinX * 1.5f, Random.Range(gameGrid.currentGridBottom, gameGrid.currentGridTop)) : 
                                    new Vector3(gameGrid.gridMaxX * 1.5f, Random.Range(gameGrid.currentGridBottom, gameGrid.currentGridTop));

            GameObject cloudGO = Instantiate(cloudPrefab, spawnPos, Quaternion.identity, cloudHolder);
            Cloud cloud = cloudGO.GetComponent<Cloud>();

            int randomSprite = Random.Range(0, cloudSprites.Length);
            int randomColor = Random.Range(0, colors.Length);

            cloud.InitCloud(cloudSprites[randomSprite], colors[randomColor], dir);

            clouds.Add(cloudGO);
        }
    }
}