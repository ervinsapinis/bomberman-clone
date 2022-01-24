using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");

        transform.position = new Vector3(player.transform.position.x + 6, 3, -10);
    }
}
