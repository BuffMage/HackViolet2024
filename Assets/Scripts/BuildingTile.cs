using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile : MonoBehaviour
{

    private Vector2Int coords;

    public void SetCoords(Vector2Int coords)
    {
        this.coords = coords;
    }

    private void OnMouseOver() 
    {
        Debug.Log($"Mouse over cube: {coords}");
        GameObject.Find("Pointer").transform.position = gameObject.transform.position;
    }
}
