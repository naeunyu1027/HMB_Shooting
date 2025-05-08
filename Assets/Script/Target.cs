using UnityEngine;


public class Target : MonoBehaviour
{
    //public AudioClip audio;
    private AudioSource audioSource;
    GameController gameController1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController1 = FindObjectOfType<GameController>();

        //audioSource.clip = audio;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Player.Instance.targetAudio.Play();
        }
        if (collision.CompareTag("bullet") || collision.CompareTag("Respawn")||collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Player"))
        {
            gameController1.GetScore1();
        }

    }
  
}

