using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    #region Fields

    public GameObject content;  //Reference to whatever is inhabiting the tile.
    public bool empty;          //Whether the tile is empty or not

    #region DELETE
    public bool occupiedByPlayer;
    
    public bool occupiableByPlayer;
    #endregion


    #endregion


	void Start () {

    }
	
	void Update () {


	}

    #region delete
    /// <summary>
    /// Checks to see if it's currently being occupied by the player
    /// </summary>
    public void CheckOccupied()
    {
        if (occupiedByPlayer == true)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow; //Yelow if true
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white; //Nothing otherwise
        }
    }

    /// <summary>
    /// Checks to see if it's reachable by the player
    /// </summary>
    public void CheckOccupiable()
    {
        if (occupiableByPlayer == true && empty == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red; //Red if true
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white; //White otherwise
        }
    }
    #endregion
}
