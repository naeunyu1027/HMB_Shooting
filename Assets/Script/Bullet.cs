using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public GameObject itemPrefab;
    GameController gameController;
    public GameObject boss;
   
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("target"))
        {
            gameController.GetScore();
            float randomValue = Random.Range(0f, 2f);

        if (randomValue <= 0.2f)
        {
            GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        }
        if (collision.CompareTag("ground")||collision.CompareTag("target")||collision.CompareTag("boss"))
        {
            // 오브젝트 삭제
            Destroy(gameObject); 
        }
    }
}
