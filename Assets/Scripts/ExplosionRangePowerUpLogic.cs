using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRangePowerUpLogic: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject instance = GameObject.Find("GameLogic");
        if (collision.transform.name == "player")
        {
            Debug.Log("Picked up power up for explosion range");
            instance.GetComponent<GameLogic>().IncrementExplosionRadius();
            Destroy(gameObject);
        }
    }
}
