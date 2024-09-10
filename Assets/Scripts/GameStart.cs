using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public float _time;
    public float _start = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController._hp = 100;
            PaperController._speed = 6.0f;
            CabbageController._speed = 5.0f;
            DogController._speed = 4.0f;
            ObjectGenerator.span = 4.0f;
            SceneManager.LoadScene("MainScene");
        }
    }
}
