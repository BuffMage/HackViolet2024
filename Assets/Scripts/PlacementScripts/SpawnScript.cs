using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = Vector3.one * .9f;
        LeanTween.scale(gameObject, Vector3.one, .5f).setEaseInOutElastic();
    }
}
