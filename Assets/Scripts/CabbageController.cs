using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageController : MonoBehaviour
{
    public static float _speed = 5f;
    Rigidbody2D _rb = default;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(1 * _speed, _rb.velocity.y);

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
