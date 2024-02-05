using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveGenerator : MonoBehaviour
{
    
    private float[] spawnZ = new float[] {5.5f, 4.5f, 3.5f, 2.5f, 1.5f, .5f, -.5f, -1.5f, -2.5f};
    private float spawnX = 3.0f;

    [SerializeField] int spawnDelay  = 4;

    [SerializeField]
    int currentWave = 0;

    float[] waveDelays = new float[] {8f, 4f, 2f, 1f, .75f};
    float[] waveLengths = new float[] {60f, 45f, 30f, 30f, 30f};

    //float[] waveLengths = new float[] {10f, 10f, 10f, 10f, 10f};

    public CanvasGroup waveUI;
    public TextMeshProUGUI waveText;

    [SerializeField]
    private float waveTimer = 0f;

    private bool nextRoundStarting = false;

    public GameObject[] Guys;

    private bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon) return;
        waveTimer += Time.deltaTime;
        if (waveTimer > 3f && nextRoundStarting)
        {
            //waveUI.alpha = 1f;
            waveText.text = $"WAVE {currentWave + 1}";
            nextRoundStarting = false;
            waveTimer = 0f;
            StartCoroutine(ShowWaveText());
        }
        else if (waveTimer > waveLengths[currentWave])
        {
            currentWave++;
            if (currentWave == waveDelays.Length)
            {
                gameWon = true;
                SceneManager.LoadScene("WinScreen");
            }
            waveTimer = 0f;
            nextRoundStarting = true;
        }
    }


    private IEnumerator ShowWaveText()
    {
        waveUI.LeanAlpha(1f, 1f);
        yield return new WaitForSeconds(3f);
        waveUI.LeanAlpha(0f, 1f);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(waveDelays[currentWave]);

            if (nextRoundStarting) continue;

            spawn();
        }
    }

    private void spawn()
    {
        int enemy = Random.Range(0, 3);
        int spawnLocation = Random.Range(0, 10);

        GameObject obj = Instantiate(Guys[enemy], new Vector3(spawnX,Guys[enemy].transform.position.y,spawnLocation - 2.5f), Guys[enemy].transform.rotation);
        //obj.GetComponent<BoxCollider>().transform.position = new Vector3(0, 0.6f, 0);

    }
}


public enum EnemyType
{
    SMOG,
    BARREL,
    MICROPLASTIC
}