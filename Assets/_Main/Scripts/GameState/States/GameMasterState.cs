using System;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameMasterState : AGameState
    {
        public override IInputController InputController { get; set; }
        public override GameStateType StateType { get; set; }

        private bool gameMasterEnabled = false;

        public GameMasterState(GameMasterInputController inputController)
        {
            InputController = inputController;
            StateType = GameStateType.GameMaster;
        }

        public override void Loop()
        {
            // Enabled or Disable GameMaster
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                gameMasterEnabled = !gameMasterEnabled;
            }

            if (gameMasterEnabled)
            {
                GameMasterCommands();
            }
        }

        private void GameMasterCommands()
        {
            // Spawn random block
            if (Input.GetKeyDown(KeyCode.B))
            {

            }

            // Reset block
            if (Input.GetKeyDown(KeyCode.R))
            {

            }

            // Spawn block 01
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(1);
            }

            // Spawn block 02
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(2);
            }

            // Spawn block 03
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(3);
            }

            // Spawn block 04
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(4);
            }

            // Spawn block 05
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(5);
            }

            // Spawn block 06
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(6);
            }

            // Spawn block 07
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnBlock(7);
            }
        }

        private void SpawnBlock(int value)
        {

        }
    }
}