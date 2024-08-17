using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjecencyGenerator : MonoBehaviour
{
    //Generates the adjeceny rules for tiles

    public List<Tile> Tiles = new List<Tile>();

    private void Awake()
    {
        GenerateAdjecencies();
    }
    void GenerateAdjecencies()
    {
        //Checks a tile agianst each other tile and determins in what ways they are compatable
        foreach (Tile t1 in Tiles)
        {
            t1.upNeighbours.Clear();
            t1.downNeighbours.Clear();
            t1.rightNeighbours.Clear();
            t1.leftNeighbours.Clear();

            foreach (Tile t2 in Tiles)
            {
                if (t1.upType == t2.downType)
                {
                    t1.upNeighbours.Add(t2);
                }
                if (t1.downType == t2.upType)
                {
                    t1.downNeighbours.Add(t2);
                }
                if (t1.rightType == t2.leftType)
                {
                    t1.rightNeighbours.Add(t2);
                }
                if (t1.leftType == t2.rightType)
                {
                    t1.leftNeighbours.Add(t2);
                }
            }
        }
    }

}
