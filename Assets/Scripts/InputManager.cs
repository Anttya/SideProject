using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameplayState
{
    Pause,
    NothingSelected,
    PlayerSelected
}

/// <summary>
/// Class to handle input from the player
/// </summary>
public class InputManager : MonoBehaviour {

    public GameplayState gameState;
    //BoardManager boardManager;
    //public bool TileSelection;

	// Use this for initialization
	void Start () {
        //boardManager = GetComponent<BoardManager>();
        //TileSelection = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if(TileSelection == true)
        //{
        //    ChooseTile();
        //}
        //else
        //{
        //    PlayerMovementPhase();
        //}
	}

    private void CheckForStateSwitch()
    {
        switch(gameState)
        {
            case GameplayState.Pause:
                //Check for menu exit
                break;
            case GameplayState.NothingSelected:
                //Check for mouse selection on player
                break;
            case GameplayState.PlayerSelected:
                //Check for some kind of attack
                break;
        }
    }

    //private void PlayerMovementPhase()
    //{
    //    boardManager.CheckPossibleMovement();
    //}

    //private void ChooseTile()
    //{
    //    boardManager.MovePlayer();
    //}

    //private void CheckMouseIndex()
    //{
    //    //Get the mouse's position in world space
    //    Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

    //}
}
