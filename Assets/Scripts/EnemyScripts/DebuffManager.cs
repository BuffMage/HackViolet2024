using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    //REDO THIS SONNNNNNNNN
    //Make the dicitonary itself ambiguous, then
    //figure it out from there
    private Dictionary<TowerControl, float> affectedTowers;
    
    // Start is called before the first frame update
    void Start()
    {
        affectedTowers = new Dictionary<TowerControl, float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ambiguous target in the case that we apply debuffs to enemies
    //for whatever reason
    public void ApplyDebuff(GameObject Target, float time)
    {
        Debug.Log("DEBUFF APPLIED");
        if(Target.GetComponent<TowerControl>() != null)
        {

            TowerControl te = Target.GetComponent<TowerControl>();
            if(affectedTowers.ContainsKey(te))
            {
                Debug.Log("Tower Found!");
                
                affectedTowers[Target.GetComponent<TowerControl>()] = time;
            }
        }
        else if(Target.GetComponent<Enemy>() != null)
        {
            //No currently a thing, may be later
        }
    }

    private void StartDebuff(TowerControl tower)
    {
        tower.SetDamage(tower.GetDamage() / 2);
        tower.SetSpeed(tower.GetSpeed() * 2);
    }

    private void StartDebuff(Enemy enemy)
    {
        //Unimplemented
    }

    private void EndBuff(TowerControl tower)
    {
        affectedTowers.Remove(tower);
        tower.SetDamage(tower.GetDamage() * 2);
        tower.SetSpeed(tower.GetSpeed() / 2);
    }

    private void EndBuff(Enemy enemy)
    {
        //Unimplemented
    }

    //Every second subtract by 1??
    private IEnumerator DebuffCycle()
    {
        while(true)
        {
            List<TowerControl> keys = affectedTowers.Keys.ToList();
            for(int i = 0; i < keys.Count; i++)
            {
                affectedTowers[keys[i]] -= 1;
                if(affectedTowers[keys[i]] < .01f)
                {
                    EndBuff(keys[i]);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
