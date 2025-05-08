using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float HP = 1f;
    public GameObject UIHP;
    GameController gameController;

    void Start()
    {
        Invoke("simulate", 5f);
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (HP <= 0f)
        {
            Debug.Log("Hello");
            gameController.clear1();
        }
    }

    void simulate()
    {
       Rigidbody2D rb = GetComponent<Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet")){
            
            HP -= 0.01f;
            UIHP.GetComponent<Slider>().value = HP;
        }
    }
}
