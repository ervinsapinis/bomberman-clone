using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bombSpawner : MonoBehaviour
{
    public Tilemap gridMap;
    public GameObject bombObject;
    public GameObject player;
    public Tilemap blocked;
    public GameLogic counter;

    // Update is called once per frame
    /// <summary>
    /// Needs a reference to the correct tilemap 
    /// </summary>
    void Update()
    {
        // if statement for when user clicks the '0' mouse button (left click)
        if (Input.GetMouseButtonDown(0))
        {
            //gets screen coordinates from the mouse click and converts into world coordinates. left as Vector2 for now, change to Vector3 in case of errors.
            //update1 - updated vector2 to var for now.
            var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //this variable gets the cell on the tilemap which has been click on by the player. Vector3Int used because its stores integers, and cells are integers.
            var cell = gridMap.WorldToCell(worldPoint);
            //this variable gets the center position of the selected cell.
            var centerCellPos = gridMap.GetCellCenterWorld(cell);
            var xPos = centerCellPos.x;
            var yPos = centerCellPos.y - 0.4f;
            var zPos = centerCellPos.z;
            var bombPos = new Vector3(xPos, yPos, zPos);

            //instancing of the bomb object. Positions the bomb in the centerCellPos which is the center, and Quaternion.identity means the object is not rotated.
            Instantiate(bombObject, bombPos, Quaternion.identity);
        }

        //checks if player is alive, the button space is pressed, and if count of bombs is not less than zero
        if (player.GetComponent<PlayerMovement>().isPlayerAlive && Input.GetButtonDown("Jump") && counter.PlayerBombCounter > 0)
        {
            counter.DecrementBombCounter();
            PlayerPlaceBomb();
            Debug.Log(counter.PlayerBombCounter);
            Invoke("Increment", 3);
        }
    }

    void Increment()
    {
        counter.IncrementBombCounter();
    }

    public bool PlayerPlaceBomb()
    {
        var playerPos = player.transform.position;
            var playerCell = gridMap.WorldToCell(playerPos);
            Tile checkTile = gridMap.GetTile<Tile>(playerCell);

            //this variable gets the center position of the selected cell.
            var centerCellPos = gridMap.GetCellCenterWorld(playerCell);
            var xPos = centerCellPos.x;
            var yPos = centerCellPos.y - 0.4f;
            var zPos = centerCellPos.z;
            var bombPos = new Vector3(xPos, yPos, zPos);

            //instancing of the bomb object. Positions the bomb in the centerCellPos which is the center, and Quaternion.identity means the object is not rotated.
            if (checkTile != blocked)
            {
                Instantiate(bombObject, bombPos, Quaternion.identity);
            }
            return true;
    }
}
