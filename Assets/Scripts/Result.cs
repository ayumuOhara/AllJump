using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject clear;
    public GameObject miss;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController._hp > 0)
        {
            clear.SetActive(true);
        }
        else if(PlayerController._hp <= 0)
        {
            miss.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
