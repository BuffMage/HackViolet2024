using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile : MonoBehaviour
{

    private Vector2Int coords;
    private GameObject currentBuilding;

    public void SetCoords(Vector2Int coords)
    {
        this.coords = coords;
    }

    public bool PlaceBuilding(GameObject building)
    {
        if (currentBuilding != null) return false;
        GameObject newObj = Instantiate(ItemPlacement.Instance.GetBuilding(), gameObject.transform.position, Quaternion.identity);
        //newObj.transform.localScale = Vector3.one * .5f;
        currentBuilding = newObj;
        Debug.Log($"Placed {currentBuilding.name}!");
        return true;
    }

    public void RemoveBuilding()
    {
        if (currentBuilding == null) return;
        Debug.Log($"Destroyed {currentBuilding.name}!");
        Destroy(currentBuilding);
    }
}
