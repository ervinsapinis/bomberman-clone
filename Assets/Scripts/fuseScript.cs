using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class fuseScript : MonoBehaviour
{
    //countdowntimer of 2secs
    public float fuseTimer = 3f;
    // Update is called once per frame
    void Update()
    {
        //reduce timer by one each second
        fuseTimer -= Time.deltaTime;

        if (fuseTimer <= 0)
        {
            //explosion
            FindObjectOfType<destruction>().Explode(transform.position);
            //remove object from grid.
            Destroy(gameObject);
        }
    }
}
