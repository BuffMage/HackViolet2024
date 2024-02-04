using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{

    private float[] spawnY = new float[] {-4.5f, -3.5f, -2.5f, -1.5f, -.5f, .5f, 1.5f, 2.5f, 3.5f, 4.5f};

    [SerializeField] int spawnDelay;

    public GameObject smog;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawnDelay);


    }

    private void spawn()
    {

    }
}


public enum EnemyType
{
    SMOG,
    BARREL,
    MICROPLASTIC
}