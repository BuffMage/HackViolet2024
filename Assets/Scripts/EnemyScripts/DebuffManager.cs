using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    //Tower dictionary
    private Dictionary<TowerControl, float> affectedTowers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ambiguous target in the case that we apply debuffs to enemies
    //for whatever reason
    public void ApplyDebuff(GameObject Target, float time)
    {
        if(Target.GetComponent<TowerControl>() != null)
        {
            if(affectedTowers.Keys.Contains(Target.GetComponent<TowerControl>()))
            {
                Debug.Log("Tower Found!");
            }
        }
        else if(Target.GetComponent<Enemy>() != null)
        {
            //No currently a thing, may be later
        }
    }


}
