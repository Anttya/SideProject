using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    public GameObject tile;
    public bool occupiedByPlayer;
    public bool empty;
    public bool occupiableByPlayer;
    public Vector2 index;
    private InputManager iManager;
    public string test;

	void Start () {
        iManager = GameObject.Find("GameManager").GetComponent<InputManager>();
        index.x = (int)index.x;
        index.y = (int)index.y;
    }
	
	void Update () {
        CheckOccupied();
        CheckOccupiable();
	}

    /// <summary>
    /// Checks to see if it's currently being occupied by the player
    /// </summary>
    public void CheckOccupied()
    {
        if (occupiedByPlayer == true)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.yellow; //Yelow if true
        }
        else
        {
            tile.GetComponent<SpriteRenderer>().color = Color.white; //Nothing otherwise
        }
    }

    /// <summary>
    /// Checks to see if it's reachable by the player
    /// </summary>
    public void CheckOccupiable()
    {
        if (occupiableByPlayer == true && iManager.TileSelection == true && empty == true)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.red; //Red if true
        }
        else
        {
            tile.GetComponent<SpriteRenderer>().color = Color.white; //White otherwise
        }
    }

}
