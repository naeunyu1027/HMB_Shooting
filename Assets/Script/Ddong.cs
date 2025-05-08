using UnityEngine;


public class Ddong : MonoBehaviour
{
    public AudioClip audio1;
    private AudioSource audioSource1;
    GameController gameController2;
    Player playerscript;

    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        gameController2 = FindObjectOfType<GameController>();
        playerscript = FindObjectOfType<Player>();

        audioSource1.clip = audio1;
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Player.Instance.targetAudio.Play();
            playerscript.speed = 3f;
            Invoke("speeeeed", 4);
        }
        if (collision.CompareTag("bullet") || collision.CompareTag("Respawn") || collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Player"))
        {
            gameController2.GetScore1();
        }

    }

    public void speeeeed()
    {
        playerscript.speed = 7f;
    }

}

