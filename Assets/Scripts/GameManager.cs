using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (PlayerController._hp <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }

        if(time >= 59 && PlayerController._hp > 0)
        {
            SceneManager.LoadScene("ResultScene");
        }

        if (time >= 56)
        {
            PaperController._speed = 8.0f;
            CabbageController._speed = 7.0f;
            DogController._speed = 6.0f;
            ObjectGenerator.span = 0.2f;
        }
        else if (time >= 50)
        {
            PaperController._speed = 9.0f;
            CabbageController._speed = 8.0f;
            DogController._speed = 7.0f;
            ObjectGenerator.span = 0.8f;
        }
        else if (time >= 40)
        {
            PaperController._speed = 8.5f;
            CabbageController._speed = 7.5f;
            DogController._speed = 6.5f;
            ObjectGenerator.span = 1.0f;
        }
        else if (time >= 30)
        {
            PaperController._speed = 8.0f;
            CabbageController._speed = 7.0f;
            DogController._speed = 6.0f;
            ObjectGenerator.span = 2.0f;
        }
        else if(time >= 20)
        {
            PaperController._speed = 6.5f;
            CabbageController._speed = 5.5f;
            DogController._speed = 4.5f;
            ObjectGenerator.span = 3.5f;
        }
    }
}
