using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FSM to keep track of inputManager's behaviour
/// </summary>
public enum GameplayState
{
    Pause,
    NothingSelected,
    PlayerSelected
}

/// <summary>
/// Input Manager class keeps track of inputs. 
/// </summary>
public class InputManager : MonoBehaviour {


	// Use this for initialization
	void Start () {

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



    //private void PlayerMovementPhase()
    //{
    //    boardManager.CheckPossibleMovement();
    //}

    //private void ChooseTile()
    //{
    //    boardManager.MovePlayer();
    //}

    private void CheckMouseIndex()
    {
        //Get the mouse's position in world space
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

    }
}
