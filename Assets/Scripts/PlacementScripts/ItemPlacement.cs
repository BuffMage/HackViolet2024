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

/*     public GameObject windGood;
    public GameObject windBad;
    public GameObject solarGood;
    public GameObject solarBad;
    public GameObject scrubGood;
    public GameObject scrubBad;
    public GameObject recGood;
    public GameObject recBad;
 */
    public GameObject[] placers;

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
                int buildingCost = GetBuilding().GetComponent<TowerControl>().GetCost();
                //Debug.Log(buildingCost);
                //int buildingCost = 0;
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

        int cost = GetBuilding().GetComponent<TowerControl>().GetCost();
        for (int i = 0; i < buildings.Length; i++)
        {
            if (i == (int)buildingToPlace)
            {
                if (cost <= totalMoney)
                {
                    placers[i * 2].SetActive(true);
                    placers[i * 2 + 1].SetActive(false);
                }
                else
                {
                    placers[i * 2].SetActive(false);
                    placers[i * 2 + 1].SetActive(true);
                }
            }
            else
            {
                placers[i * 2].SetActive(false);
                placers[i * 2 + 1].SetActive(false);
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
        //Debug.Log("Money Changed");
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