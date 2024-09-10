using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _score = 0;
    [SerializeField] float _speed = 10f;
    [SerializeField] float _jump = 500f;
    Rigidbody2D _rb = default;
    bool isGround = true;
    public static float _hp;
    public float _maxHP = 100;
    bool leftButton = false;
    bool rightButton = false;
    public Image hpbar;
    public TextMeshProUGUI scoreText;

    private string answerTag = "";

    // Start is called before the first frame update
    void Start()
    {
        _hp = _maxHP;
        _rb = GetComponent<Rigidbody2D>();
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((x) =>
        {
            Jump();
        });

        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "当たった数：" + _score;
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = _hp / _maxHP;
        hpbar.fillAmount = fillAmount;

        if (leftButton)
        {
            _rb.velocity = new Vector2(-1 * _speed, _rb.velocity.y);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (rightButton)
        {
            _rb.velocity = new Vector2(1 * _speed, _rb.velocity.y);
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        if (!(leftButton) && !(rightButton))
        {
            //移動を停止した際にx速度をゼロにする
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (isGround)
        {
            _rb.AddForce(Vector2.up * _jump);
            isGround = false;
        }
    }

    // ボタンを離したときにピタッと止めるために必要
    public void OnLeftDown()
    {
        leftButton = true;
    }
    public void OnLeftUp()
    {
        leftButton = false;
    }
    public void OnRightDown()
    {
        rightButton = true;
    }
    public void OnRightUp()
    {
        rightButton = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _rb.AddForce(Vector2.down * _jump);
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        answerTag = other.gameObject.tag;
        _score++;
        scoreText.text = "当たった数：" + _score;

        switch (answerTag)
        {
            case "Paper":
                _hp -= 2.5f;
                Destroy(other.gameObject);
                break;
            case "Cabbage":
                _hp -= 5;
                Destroy(other.gameObject);
                break;
            case "Dog":
                _hp -= 10;
                Destroy(other.gameObject);
                break;
        }
    }
}
