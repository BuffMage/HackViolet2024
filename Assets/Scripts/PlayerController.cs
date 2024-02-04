using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private GameObject healthDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            Lose();
        }

        DisplayText();
    }

    void Lose()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void Damage(int amt)
    {
        health -= amt;
    }

    //Maybe be needed later
    public void Heal(int amt)
    {
        health += amt;
    }

    public void DisplayText()
    {
        healthDisplay.GetComponent<TextMeshProUGUI>().text = "Health: " + health.ToString();
    }
}
