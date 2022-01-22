using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameLogic : MonoBehaviour
    {
        //ref to player
        public GameObject player;

        public static int playerLives = 2;

        private void Update()
        {
            if (player.GetComponent<PlayerMovement>().isPlayerAlive == false && playerLives > 0)
            {
                decrementPlayerLives();
                Restart();
            }

            if (playerLives <= 0)
                Debug.Log("GAME OVER");
        }

        public void decrementPlayerLives()
        {
            playerLives--;
            Debug.Log($"remaining lives: {playerLives}");
        }

        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}