using UnityEngine;

namespace EdwinGameDev
{
    public class GridUnit
    {
        public GameObject gameObject { get; private set; }
        public GameObject tileOnGridUnit;
        public Vector2Int location { get; private set; }
        public bool isOccupied;

        public GridUnit(GameObject newGameObject, Transform boardParent, int x, int y)
        {
            gameObject = GameObject.Instantiate(newGameObject, boardParent);
            location = new Vector2Int(x, y);
            isOccupied = false;

            gameObject.transform.position = new Vector3(location.x, location.y);
        }
    }
}