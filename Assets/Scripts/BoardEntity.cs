using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class for all board objects
/// </summary>
public abstract class BoardEntity : MonoBehaviour {

    public Vector2Int boardIndex;   //Every board entity knows about its index within the board 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Must be overriden to program board behaviour
    /// </summary>
    abstract public void OnTarget();

    /// <summary>
    /// Handles what will happen once a board object is selected, but not necessarily attacked
    /// </summary>
    abstract public void OnSelect();
}
