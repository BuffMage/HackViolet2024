using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public float tileSize = 1f;
    public Vector2Int levelDims = new Vector2Int(30, 10);

    public Material mat1;
    public Material mat2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelDims.x; i++)
        {
            for (int j = 0; j < levelDims.y; j++)
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Plane);
                newCube.transform.position = new Vector3(i * tileSize * 2 - (levelDims.x * tileSize / 2), 0, j * tileSize * 2 - (levelDims.y * tileSize / 2));
                newCube.transform.localScale = Vector3.one * tileSize / 5;
                //newCube.GetComponent<MeshRenderer>().enabled = false;
                newCube.transform.SetParent(gameObject.transform);
                newCube.layer = LayerMask.NameToLayer("BuildingTiles");
                newCube.GetComponent<MeshRenderer>().material = ((i + j) % 2 == 0) ? mat1: mat2;
                newCube.AddComponent<BuildingTile>().SetCoords(new Vector2Int(i, j));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
