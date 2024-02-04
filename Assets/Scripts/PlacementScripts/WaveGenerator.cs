using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    
    private float[] spawnZ = new float[] {5.5f, 4.5f, 3.5f, 2.5f, 1.5f, .5f, -.5f, -1.5f, -2.5f};
    private float spawnX = 3.0f;

    [SerializeField] int spawnDelay  = 4;

    public GameObject[] Guys;

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
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);

            spawn();
        }
    }

    private void spawn()
    {
        int enemy = Random.Range(0, 3);
        int spawnLocation = Random.Range(0, 9);

        Instantiate(Guys[enemy], new Vector3(spawnX,0.25f,spawnLocation-1), Guys[enemy].transform.rotation);

    }
}


public enum EnemyType
{
    SMOG,
    BARREL,
    MICROPLASTIC
}