using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRangePowerUpLogic: MonoBehaviour
{
    public GameLogic logic; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "player")
        {
            Debug.Log("Picked up power up for explosion range");
            logic.IncrementExplosionRadius();
        }
    }
}
