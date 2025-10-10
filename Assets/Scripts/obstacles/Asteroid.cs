using UnityEngine;

public class Asteroid : MonoBehaviour
{
   private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();   
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned to Asteroid!");
            return;
        }
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        float moveX = Random.Range(-1f, 0f);
        float moveY = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(moveX, moveY).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = (GameManager.Instance.worldSpeed * PlayerController.Instance.boost) * Time.deltaTime; 
        transform.position += new Vector3(moveX , 0);
        if(transform.position.x < -12 ){
            Destroy(gameObject);
        }

    }
}
