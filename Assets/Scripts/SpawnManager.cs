using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    #region Fields
    GameObject[,] GameBoard; //A reference to the Board Manager's gameboard

    //References to our prefabs (May replace with dictionary in the future!!!)
    public GameObject playerPrefab;
    public GameObject rockPrefab;
    //public Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>(); //This class holds our prefab dictionary, where we hold all our prefabs
    #endregion

    // Use this for initialization
    void Start () {
        GameBoard = GetComponent<BoardManager>().GameBoard; //Initialize our game board reference

        //Spawn a player and some rocks
        SpawnPlayer();
        SpawnObstacles(5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Method called to spawn "rocks" or other obstacles
    /// </summary>
    /// <param name="n">How many to spawn</param>
    private void SpawnObstacles(int n)
    {
        //Annie: you might need this, a reference to how the number of rocks was calculated before i deleted it :^)
        //int maxNum = (int)((boardDimensions.x * boardDimensions.y) / 2); //Max number of rocks that will be spawned. Dependent on board size
        for (int i = 1; i <= n; i++)
        {
            RandomSpawn(rockPrefab); //Place n obstacles randomly on the board
        }
    }

    /// <summary>
    /// Method called to spawn the player.
    /// </summary>
    private void SpawnPlayer()
    {
        RandomSpawn(playerPrefab); //Randomly place a "player" prefab on the board
    }

    /// <summary>
    /// Utility method to spawn something within the board at a random position
    /// </summary>
    /// <param name="prefab">what to spawn</param>
    public void RandomSpawn(GameObject prefab)
    {
        Vector2Int randomIndex = GetRandomEmptyBoardIndex(); //Get a valid random index to spawn at

        Vector2 location = GameBoard[randomIndex.x, randomIndex.y].transform.position; //Get the position of the tile at that index

        GameObject instance = Instantiate(prefab, location, Quaternion.identity); //Spawn the object

        instance.name = prefab.name;

        //instance.GetComponent<BoardEntity>().boardIndex = randomIndex;  //objects hold a reference to their own index              

        //TODO: add the instance to some kind of master list of spawned gameObjects (enemies, obstacles, etc)

        TileInfo thisTile = GameBoard[randomIndex.x, randomIndex.y].GetComponent<TileInfo>();   //Reference to the tile info for this index of gameboard

        //Assign values to the tile's held attributes
        thisTile.content = instance;
        thisTile.empty = false;
    }

    /// <summary>
    /// Utility method to spawn something within the board at a specific index
    /// </summary>
    /// <param name="prefab">what to spawn</param>
    /// <param name="index">the index to spawn it at</param>
    public void SpawnAtIndex(GameObject prefab, Vector2Int index)
    {
        try
        {
            if(IsValidIndex(index))
            {
                Vector2 location = GameBoard[index.x, index.y].transform.position; //Get the position of the tile at that index
                GameObject instance = Instantiate(prefab, location, Quaternion.identity); //Spawn the object
                //instance.GetComponent<BoardEntity>().boardIndex = index;  //objects hold a reference to their own index     
                //TODO: add the instance to some kind of master list of spawned gameObjects (enemies, obstacles, etc)

                TileInfo thisTile = GameBoard[index.x, index.y].GetComponent<TileInfo>();   //Reference to the tile info for this index of gameboard

                //Assign values to the tile's held attributes
                thisTile.content = instance;
                thisTile.empty = false;
            }
        }
        catch(System.IndexOutOfRangeException e) //For future debugging in case an outofrange index is ever to be parametrized.
        {
            Debug.Log(e.Message);
        }
    }

    

    /// <summary>
    /// Helper method for getting a VALID random index within the board
    /// </summary>
    /// <returns>A valid (non-empty) board index</returns>
    private Vector2Int GetRandomEmptyBoardIndex()
    {
        Vector2Int randomIndex = GetRandomBoardIndex();

        //NOTE: this can be made smarter
        while (!IsValidIndex(randomIndex)) //Check if the gameBoard is empty at the selected index
        {
            randomIndex = GetRandomBoardIndex();
        }

        return randomIndex;
    }

    /// <summary>
    /// Helper method for getting a random index within our game board
    /// </summary>
    /// <returns>a random index within the board</returns>
    private Vector2Int GetRandomBoardIndex()
    {
        return new Vector2Int(Random.Range(0, GameBoard.GetLength(0)), Random.Range(0, GameBoard.GetLength(1)));
    }

    /// <summary>
    /// Helper method to check whether an index is occupied
    /// </summary>
    /// <param name="randomIndex">the index to check</param>
    /// <returns>whether that space on the board is currently occupied</returns>
    private bool IsValidIndex(Vector2Int randomIndex)
    {
        return GameBoard[randomIndex.x, randomIndex.y].GetComponent<TileInfo>().empty;
    }
}
