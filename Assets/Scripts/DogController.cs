using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public static float _speed = 4f;
    [SerializeField] float _jump = 600f;
    Rigidbody2D _rb = default;
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpCouroutine());
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

    IEnumerator JumpCouroutine()
    {
        Debug.Log("コルーチン開始");
        while(true)
        {
            int i = Random.Range(1, 4);
            if (i == 1)
            {
                if (isGround)
                {
                    _rb.AddForce(Vector2.up * _jump);
                    isGround = false; // ジャンプ後は地面にいない
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
