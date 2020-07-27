using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class EndLine : MonoBehaviour
    {
        public GameData gameData;
        public Vector3 offset;

        private void OnEnable()
        {
            transform.position = new Vector3(offset.x, offset.y + gameData.heightToWin, offset.z);
        }
    }
}