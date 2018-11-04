using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour {

    #region Fields
    //Default Screen Dimensions (Based on this machine)
    private Vector2 defaultDimensions = new Vector2(1181, 442); //TODO: get rid of this
    public Vector3 worldPosition;
    public Vector3 position;
    public Vector2 min;
    public Vector2 max;

    public Vector2 newBounds
    {
        get
        {
            float percentChanged = Mathf.Sqrt((defaultDimensions.x / Screen.width) + (defaultDimensions.y / Screen.height)); //Comment here
            return new Vector2(percentChanged, percentChanged);
        }
    }

    public Vector2 FindMin
    {
        get
        {
            return GetComponent<SpriteRenderer>().bounds.min;
        }
    }

    public Vector2 FindMax
    {
        get
        {
            return GetComponent<SpriteRenderer>().bounds.max;
        }
    }
    Vector2 screenBounds; //TODO: For the future!
    #endregion

    void Start () {

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //For future purposes!
        transform.localScale = newBounds;
        SetMaxMin();
        min = FindMin;
        max = FindMax;
    }
	
	void Update () {
        
        CalcuateWorldPosition();

	}

    private void CalcuateWorldPosition()
    {
        worldPosition = Camera.main.WorldToViewportPoint(position);
    }

    /// <summary>
    /// Gets position info for sprite as well as the bounds of the sprite
    /// </summary>
    private void SetMaxMin()
    {
        position = transform.position; //Gets sprite's current position

        //Set minimum and maximum points for this sprite
        //min = GetComponent<SpriteRenderer>().bounds.min; //+ transform.position; 
        //max = GetComponent<SpriteRenderer>().bounds.max; //+ transform.position;
    }
}
