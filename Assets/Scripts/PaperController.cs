using System.Collections;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    public static float _speed = 6f;
    Rigidbody2D _rb = default;
    public float _time = 0;
    bool _isStop = false;
    int _stop = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if(_isStop == false)
        {
            _stop = Random.Range(3, 6);
        }

        if(_time > _stop)
        {
            _isStop = true;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(1 * _speed, _rb.velocity.y);
        }

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

}
