using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour {

    #region Fields
    //Default Screen Dimensions (Based on this machine)
    private Vector2 defaultDimensions = new Vector2(1181, 442); //TODO: get rid of this
    public Vector3 position;

    public Vector2 NewBounds
    {
        get
        {
            float percentChanged = Mathf.Sqrt((defaultDimensions.x / Screen.width) + (defaultDimensions.y / Screen.height)); //Comment here
            return new Vector2(percentChanged, percentChanged);
        }
    }

    #region min/max accessor properties
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
    #endregion 

    #endregion

    void Start () {
        transform.localScale = NewBounds;
    }
	
	void Update () {

	}
}
