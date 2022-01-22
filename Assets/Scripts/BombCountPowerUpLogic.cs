using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCountPowerUpLogic : MonoBehaviour
{
    public GameLogic logic; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "player")
        {
            Debug.Log("Picked up power up");
            logic.IncrementBombCounter();
        }
    }
}
