using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    GameObject prefab_rnd;
    [SerializeField] GameObject _prefabPaper;
    [SerializeField] GameObject _prefabCabbage;
    [SerializeField] GameObject _prefabDog;
    public static float span = 4.0f;
    int _rnd_y = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        while (true)
        {
            int _rnd = 1; // Random.Range(1, 4);
            if(_rnd == 1)
            {
                prefab_rnd = _prefabPaper;
            }
            //else if(_rnd == 2)
            //{
            //    prefab_rnd = _prefabCabbage;
            //}
            //else
            //{
            //    prefab_rnd = _prefabDog;
            //}

            var obj_1 = Instantiate(prefab_rnd);
            if(prefab_rnd == _prefabPaper)
            {
                _rnd_y = Random.Range(-3, 0);
            }
            _rnd_y = Random.Range(-3, 4);
            obj_1.transform.position = new Vector3(-20, _rnd_y, 0);
            yield return new WaitForSeconds(span);
        }
    }
}
