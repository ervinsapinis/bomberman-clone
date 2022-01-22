using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets;
using Assets.Scripts;

public class destruction : MonoBehaviour
{
    public Tilemap gridMap;

    public Tile Wall;
    public Tile Destructible;
    public GameObject Explosion;
    public Animator die;
    public GameLogic logic;
    public void Explode(Vector2 position)
    {
        //mnodifier for explosion size
        int modifier = logic.ExplosionModifier;
        var explosionOrigin = gridMap.WorldToCell(position);
        LeveledExplosion(explosionOrigin, modifier);
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Vector3 pos = gridMap.GetCellCenterWorld(cell);
        var xPos = pos.x;
        var yPos = pos.y - 0.4f;
        var zPos = pos.z;
        var actualPos = new Vector3(xPos, yPos, zPos);
        //gets tile that is exploding
        Tile BaseTile = gridMap.GetTile<Tile>(cell);
        //gets tile that player is standing upon;
        if (BaseTile == Wall) 
        {
            return false;
        }

        if (BaseTile == Destructible)
        {
            //removes tile
            gridMap.SetTile(cell, null);
            Instantiate(Explosion, actualPos, Quaternion.identity);
            return false;
        }

        //create explosion on tile if no wall or destructible is present. takes the location vector3 and instantiates an explosion.
        GameObject clone = Instantiate(Explosion, actualPos, Quaternion.identity);
        clone.GetComponent<Destroyable>().die = die;
        return true;
    }


    /// <summary>
    /// Creates an explosion of different sizes based on the explosion modifier. If modifier is 0, base explosion is offset by 1 tile in each cardinal direction.
    /// Each addition to the modifier adds another offset tile to the explosion. Maximum effective modifier is 3.
    /// </summary>
    /// <param name="cell">The center cell of the explosion</param>
    /// <param name="modifier">Modifier of the explosion size.</param>
    public void LeveledExplosion(Vector3Int cell, int modifier)
    {
        if (modifier == 1)
        {
            //center explosion
            ExplodeCell(cell);
            //offset explosions on sides. Default size iz offset by 1
            ExplodeCell(cell + new Vector3Int(1, 0, 0));
            ExplodeCell(cell + new Vector3Int(0, 1, 0));
            ExplodeCell(cell + new Vector3Int(-1, 0, 0));
            ExplodeCell(cell + new Vector3Int(0, -1, 0));
        }

        if (modifier == 2)
        {
            //center explosion
            ExplodeCell(cell);
            //offset explosions on sides. Default size iz offset by 1
            if (ExplodeCell(cell + new Vector3Int(1, 0, 0)))
            {
                ExplodeCell(cell + new Vector3Int(2, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(-1, 0, 0)))
            {
                ExplodeCell(cell + new Vector3Int(-2, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, 1, 0)))
            {
                ExplodeCell(cell + new Vector3Int(0, 2, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, -1, 0)))
            {
                ExplodeCell(cell + new Vector3Int(0, -2, 0));
            }
        }

        if (modifier == 3)
        {
            //center explosion
            ExplodeCell(cell);
            //offset explosions on sides. Default size iz offset by 1
            if (ExplodeCell(cell + new Vector3Int(1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(2, 0, 0)))
                    ExplodeCell(cell + new Vector3Int(3, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(-1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(-2, 0, 0)))
                    ExplodeCell(cell + new Vector3Int(-3, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, 1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, 2, 0)))
                    ExplodeCell(cell + new Vector3Int(0, 3, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, -1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, -2, 0)))
                    ExplodeCell(cell + new Vector3Int(0, -3, 0));
            }
        }

        if (modifier == 4)
        {
            //center explosion
            ExplodeCell(cell);
            //offset explosions on sides. Default size iz offset by 1
            if (ExplodeCell(cell + new Vector3Int(1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(2, 0, 0)))
                    if (ExplodeCell(cell + new Vector3Int(3, 0, 0)))
                        ExplodeCell(cell + new Vector3Int(4, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(-1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(-2, 0, 0)))
                    if (ExplodeCell(cell + new Vector3Int(-3, 0, 0)))
                        ExplodeCell(cell + new Vector3Int(-4, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, 1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, 2, 0)))
                    if (ExplodeCell(cell + new Vector3Int(0, 3, 0)))
                        ExplodeCell(cell + new Vector3Int(0, 4, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, -1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, -2, 0)))
                    if (ExplodeCell(cell + new Vector3Int(0, -3, 0)))
                        ExplodeCell(cell + new Vector3Int(0, -4, 0));
            }
        }

        if (modifier == 5)
        {
            //center explosion
            ExplodeCell(cell);
            //offset explosions on sides. Default size iz offset by 1
            if (ExplodeCell(cell + new Vector3Int(1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(2, 0, 0)))
                    if (ExplodeCell(cell + new Vector3Int(3, 0, 0)))
                        if (ExplodeCell(cell + new Vector3Int(4, 0, 0)))
                            ExplodeCell(cell + new Vector3Int(5, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(-1, 0, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(-2, 0, 0)))
                    if (ExplodeCell(cell + new Vector3Int(-3, 0, 0)))
                        if (ExplodeCell(cell + new Vector3Int(-4, 0, 0)))
                            ExplodeCell(cell + new Vector3Int(-5, 0, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, 1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, 2, 0)))
                    if (ExplodeCell(cell + new Vector3Int(0, 3, 0)))
                        if (ExplodeCell(cell + new Vector3Int(0, 4, 0)))
                            ExplodeCell(cell + new Vector3Int(0, 5, 0));
            }
            if (ExplodeCell(cell + new Vector3Int(0, -1, 0)))
            {
                if (ExplodeCell(cell + new Vector3Int(0, -2, 0)))
                    if (ExplodeCell(cell + new Vector3Int(0, -3, 0)))
                        if (ExplodeCell(cell + new Vector3Int(0, -4, 0)))
                            ExplodeCell(cell + new Vector3Int(0, -5, 0));
            }
        }
    }
}
