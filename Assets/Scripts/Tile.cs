using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //Lists of tile which can be placed, above, right, down and left of this tile
    public List<Tile> upNeighbours = new List<Tile>();
    public List<Tile> rightNeighbours = new List<Tile>();
    public List<Tile> downNeighbours = new List<Tile>();
    public List<Tile> leftNeighbours = new List<Tile>();

    //The type of envoriment this tile has on each side
    public string upType;
    public string rightType;
    public string downType;
    public string leftType;
}