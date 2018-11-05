using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    #region Fields
    //A note on board position: make it be set smartly rather than inspector set eventually, in the game, the board's position wont ever change right?
    //A good next goal may be to make the board exactly at the center of the screen (easy)
    public GameObject tilePrefab;       //Reference to prefab of tile

    public Vector3 boardPosition;       //The position of the board in world space
    public Vector2 boardSize;
    public Vector2 worldBoardSize;
    public Vector2 boardDimensions;     //The dimensions of the board
    public GameObject[,] GameBoard;     //The board itself as an array of tiles.
    #endregion

    void Start () {
        CalculateBoardPosition();
        CreateBoard(); //Instantiate all necessary tiles
        DrawBoard();
    }


    void Update () {
        //CheckPossibleMovement();
        CheckMouseIndex();
        //GetMouse();
	}

    private void CalculateBoardPosition()
    {
        //Calculates board's size in porportion to user's screen in WorldPoint
        boardSize = new Vector2(Screen.height/2, Screen.height/2);
        worldBoardSize = Camera.main.ScreenToWorldPoint(boardSize);
        
        //Sets board position according to world point
        boardPosition = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width/2) - (boardSize.x/2), (Screen.height/2) - (boardSize.y/2), 10)); //TODO: fix this
    }

    /// <summary>
    /// Main method to draw the board (Instantiate tiles at correct locations).
    /// </summary>
    public void CreateBoard()
    {
        GameBoard = new GameObject[(int)boardDimensions.x, (int)boardDimensions.y]; //Set the board dimensions to the array
        for (int i = 0; i < boardDimensions.x; i++) //Iterate through columns X
        {
            for (int j = 0; j < boardDimensions.y; j++) //Iterate through rows Y
            {
                GameBoard[i, j] = Instantiate(tilePrefab); //Create an array of individual tiles
                GameBoard[i, j].GetComponent<TileInfo>().empty = true; //Empty upon creation
                GameBoard[i, j].name = "X: " + i + "Y: " + j; //Rename for debugging purposes
            }
        }
    }

    /// <summary>
    /// Draws and relocates tiles to the appropiate stuff
    /// TODO: Resize and moves tiles accordingly
    /// </summary>
    public void DrawBoard()
    {
        for (int i = 0; i < boardDimensions.x; i++) //Iterate through columns X
        {
            for (int j = 0; j < boardDimensions.y; j++) //Iterate through rows Y
            {
                SpriteInfo si = GameBoard[i, j].GetComponent<SpriteInfo>(); //Get Reference to this tile's spriteInfo

                //Need to correctly get each tile's size according to number of tiles & total board size. Total board size.y / number of tiles?
                //TotalBoardY = Screen.height/2 
                //BoardDimensions.Y = 2
                //Debug.Log(Camera.main.ScreenToWorldPoint(boardSize / boardDimensions));

                Vector3 tilePos = new Vector3(i * si.newBounds.x, -j * si.newBounds.y); //Calculate correct position from this spriteInfo
                GameBoard[i, j].transform.position = tilePos + new Vector3(boardPosition.x, -(boardPosition.y+(boardDimensions.y/2)*si.newBounds.y-1)); //Testing purposes so tiles are cenetered
                //GameBoard[i, j].transform.position = tilePos + new Vector3(boardPosition.x, -(boardPosition.y + (worldBoardSize.y/2))); //Should work if tile resizes properly
            }
        }
    }

    public void GetMouse()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition)); //Debug stuff
    }

    /// <summary>
    /// Moves the player once the player tile has been clicked.
    /// </summary>
    //public void CheckPossibleMovement()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Gets the mouse coords and converts to worldpoint
    //    Vector2 min = GameBoard[(int)pInfo.index.x, (int)pInfo.index.y].GetComponent<SpriteRenderer>().bounds.min; //Get tile player's on's min bounds
    //    Vector2 max = GameBoard[(int)pInfo.index.x, (int)pInfo.index.y].GetComponent<SpriteRenderer>().bounds.max; //Get tile player's on's max bounds
    //    if (mousePos.x > min.x && mousePos.y > min.y && mousePos.x < max.x && mousePos.y < max.y && Input.GetMouseButtonDown(0)) //If clicked within player tile's bounds
    //    {
    //        iManager.TileSelection = true;
    //        CheckSurrondingTiles(); //Checks to see which tile is reachable
    //    }
    //}

    /// <summary>
    /// Allows you to move the player by choosing a reachable tile.
    /// Automatically updates the new index and position
    /// </summary>
    //public void MovePlayer()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Gets the mouse coords and converts to worldpoint
    //    for (int i = 0; i < boardDimensions.x; i++) //Iterate through columns X
    //    {
    //        for (int j = 0; j < boardDimensions.y; j++) //Iterate through rows Y
    //        {
    //            Vector2 min = GameBoard[i,j].GetComponent<SpriteRenderer>().bounds.min; //Get tile's min bounds
    //            Vector2 max = GameBoard[i,j].GetComponent<SpriteRenderer>().bounds.max; //Get max bounds
    //            //Checks to see if the tile you selected is within the bounds of a reachable tile
    //            if (Input.GetMouseButtonDown(0) && mousePos.x > min.x && mousePos.y > min.y && mousePos.x < max.x && mousePos.y < max.y && GameBoard[i,j].GetComponent<TileInfo>().occupiableByPlayer == true)
    //            {
    //                GameBoard[(int)pInfo.index.x, (int)pInfo.index.y].GetComponent<TileInfo>().empty = true; //Old player tile is no longer occupied
    //                pInfo.index = new Vector2(i, j); //Set Player's new index
    //                GameBoard[(int)pInfo.index.x, (int)pInfo.index.y].GetComponent<TileInfo>().empty = false; //New player tile is no longer empty
    //                player.transform.position = GameBoard[i, j].transform.position; //Set Move player accordingly
    //                UpdatePlayerTile(); //Update new reachable tiles
    //                iManager.TileSelection = false; //No longer selecting a tile
    //            }
    //            //Cancel movement by selecting your own tile
    //            if (Input.GetMouseButtonDown(0) && mousePos.x > min.x && mousePos.y > min.y && mousePos.x < max.x && mousePos.y < max.y && GameBoard[i, j].GetComponent<TileInfo>().occupiedByPlayer == true)
    //            {
    //                iManager.TileSelection = false; //No longer selecting a tile
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// Checks to see if the player can travel to a specific tile
    /// </summary>
    //public void CheckSurrondingTiles()
    //{ 
    //    int piX = (int)pInfo.index.x; //Player's x index
    //    int piY = (int)pInfo.index.y; //Player's y index
    //    for (int i = 0; i < boardDimensions.x; i++) //Iterate through columns X
    //    {
    //        for (int j = 0; j < boardDimensions.y; j++) //Iterate through rows Y
    //        {
    //            TileInfo ti = GameBoard[i, j].GetComponent<TileInfo>(); //Get a specific tile's info
    //            if (ti.index == new Vector2(piX + 1, piY)) //Right
    //            {
    //                if (GameBoard[piX + 1, piY].GetComponent<TileInfo>().empty == true) //Checks to see if that tile is empty
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX - 1, piY)) //Left
    //            {
    //                if (GameBoard[piX - 1, piY].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX, piY + 1)) //Up
    //            {
    //                if (GameBoard[piX, piY + 1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX, piY - 1)) //Down
    //            {
    //                if (GameBoard[piX, piY - 1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            } 
    //            else if (ti.index == new Vector2(piX + 1, piY - 1)) //Bottom right
    //            {
    //                if (GameBoard[piX + 1, piY - 1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX - 1, piY + 1)) //Top left
    //            {
    //                if (GameBoard[piX - 1, piY + 1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX + 1, piY + 1)) //Top right
    //            {
    //                if (GameBoard[piX + 1, piY + 1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else if (ti.index == new Vector2(piX - 1, piY - 1)) //Bottom left
    //            {
    //                if(GameBoard[piX-1, piY-1].GetComponent<TileInfo>().empty == true)
    //                {
    //                    ti.occupiableByPlayer = true;
    //                }
    //            }
    //            else
    //            {
    //                ti.occupiableByPlayer = false; //Not reachable by the player
    //            }
    //        }
    //    }
    //}


    private void CheckMouseIndex()
    {
        //TEMPORARY CODE UNTIL SMARTER ARCHITECTURE
        SpriteInfo sample = GameBoard[0, 0].GetComponent<SpriteInfo>();
        Vector2 worldTileDimensions = new Vector2(sample.newBounds.x, sample.newBounds.y);



        //Get the mouse's position in world space
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouse2d = new Vector2(worldMousePos.x, worldMousePos.y);

        //Debug.Log(mouse2d / worldTileDimensions);
    }
}
