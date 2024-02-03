using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile : MonoBehaviour
{

    private Vector2Int coords;
    private GameObject pointerObj;

    public void SetCoords(Vector2Int coords)
    {
        this.coords = coords;
    }

    private void OnMouseOver() 
    {
        if (pointerObj == null) pointerObj = GameObject.Find("Pointer");
        Debug.Log($"Mouse over cube: {coords}");
        pointerObj.GetComponent<PointerManager>().SetTargetPos(transform.position);
    }

    private void OnMouseExit()
    {

    }

    private void OnMouseDown() 
    {
        GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        newObj.transform.position = gameObject.transform.position;
        newObj.transform.localScale = Vector3.one * .5f;
        Debug.Log("Placed Building!");
    }
}
