using UnityEngine;

public class Critter1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

    private float moveSPeed;
    private Vector3 targetPosition;
    private Quaternion targetRotation;  

    private float moveTimer;
    private float moveInterval;
   [SerializeField] private GameObject zappedEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        moveSPeed = Random.Range(0.5f, 3f);
        GenerateRandomPositions();
        moveInterval = Random.Range(0.5f, 2f);
        moveTimer = moveInterval;   
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer > 0) { 
            moveTimer -= Time.deltaTime;
        } else {
            GenerateRandomPositions();
            moveInterval = Random.Range(0.1f, 2f);
            moveTimer = moveInterval;
        }
        transform.position = Vector3.MoveTowards(transform.position,targetPosition,moveSPeed * Time.deltaTime);

        Vector3 relativePOS = targetPosition - transform.position;
        if(relativePOS != Vector3.zero){
            targetRotation = Quaternion.LookRotation(Vector3.forward, relativePOS);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1000 * Time.deltaTime);


        }

        float moveX = (GameManager.Instance.worldSpeed * PlayerController.Instance.boost) * Time.deltaTime;
        transform.position += new Vector3(moveX, 0);
    }

    private void GenerateRandomPositions()
    {
        float RandomX = Random.Range(-5f, 5f);
        float RandomY = Random.Range(-5f, 5f);
        targetPosition = new Vector2(RandomX, RandomY);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Instance.PlayModifiedSound(AudioManager.Instance.critterhit);
            Instantiate(zappedEffect, transform.position, transform.rotation);
        Destroy(gameObject);
           
        }
    }
}
