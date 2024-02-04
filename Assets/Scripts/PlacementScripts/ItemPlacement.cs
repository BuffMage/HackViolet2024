using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour
{
    public static ItemPlacement Instance;
    public BuildingType buildingToPlace;
    public GameObject[] buildings;
    public LayerMask tileLayerMask;
    public PointerManager pointer;
    public int totalMoney = 300;
    public static event Action<int> OnMoneyChanged;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointer = GameObject.Find("Pointer").GetComponent<PointerManager>();
    }

    private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, tileLayerMask))
        {
            pointer.SetTargetPos(hit.collider.transform.position);
            if (Input.GetMouseButtonDown(0))
            {
                //int buildingCost = GetBuilding().GetComponent<TowerControl>().GetCost();
                int buildingCost = 0;
                if (buildingCost <= totalMoney)
                {
                    if (hit.collider.GetComponent<BuildingTile>().PlaceBuilding(GetBuilding()))
                    {
                        totalMoney -= buildingCost;
                        OnMoneyChanged?.Invoke(totalMoney);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                hit.collider.GetComponent<BuildingTile>().RemoveBuilding();
            }
        }
    }

    public GameObject GetBuilding()
    {
        return buildings[(int)buildingToPlace];
    }

    public void setBuilding(int amt)
    {
        if(amt > 3)
        {
            amt = 3;
        }
        else if(amt < 0)
        {
            amt = 0;
        }

        buildingToPlace = (BuildingType)amt;
    }

    public bool ChangeMoney(int amount)
    {
        if (-amount > totalMoney) return false;
        totalMoney += amount;
        OnMoneyChanged?.Invoke(totalMoney);
        return true;
    }
}



public enum BuildingType
{
    WINDMILL,
    SOLARPANEL,
    RECYCLINGCENTER,
    CARBONSCRUBBER
}