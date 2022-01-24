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
        private static int _playerBombCounter = 2;
        private static int _explosionModifier = 1;
        public int slimeCounter = 7;
        public float slimeSpeed = 60f;
        public float slimeTime = 120f;
        private bool slimeFast = false;

        public int ExplosionModifier
        {
            get { return _explosionModifier; }
        }

        public int PlayerBombCounter
        {
            get { return _playerBombCounter; }
        }

        private void Update()
        {
            if (slimeTime > 0)
            {
                slimeTime -= Time.deltaTime;
            }
            if(slimeTime < 0)
            {
                if(!slimeFast)
                    slimeSpeed *= 2;
                slimeFast = true;
                
            }

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

        public void IncrementBombCounter()
        {
            _playerBombCounter++;
        }

        public void IncrementExplosionRadius()
        {
            _explosionModifier++;
        }

        public void DecrementBombCounter()
        {
            _playerBombCounter--;
        }
        public void DecrementSlimeCounter()
        {
            slimeCounter--;
        }
    }
}