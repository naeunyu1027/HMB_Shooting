using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}

    public GameObject bullet; 
    public float speed = 7f;
    private Rigidbody2D rigid;
    public Vector3 target;
    public AudioSource targetAudio;
    GameController gameController1;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = this.transform.position;
        gameController1 = FindObjectOfType<GameController>();
        targetAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(y * speed, rigid.velocity.y);

        float x = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(x * speed, rigid.velocity.x);
        ScreenChk();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            gameController1.GetScore2();
        }
    }
    private void ScreenChk() //카메라 안에 고정
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        if (worlpos.y < 0.05f) worlpos.y = 0.05f;
        if (worlpos.y > 0.95f) worlpos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }

    
}
