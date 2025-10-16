using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    Rigidbody2D rb;
    private Material defaultMaterial;
    [SerializeField] private Material Material;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        defaultMaterial = spriteRenderer.material;

        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned to Asteroid!");
            return;
        }
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        float moveX = Random.Range(-1f, 0f);
        float moveY = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(moveX, moveY).normalized;
        float scale = Random.Range(0.3f, 1.5f);
        transform.localScale = new Vector3(scale, scale);    
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet")) {
            spriteRenderer.material = Material;
            StartCoroutine(changematerial());
            AudioManager.Instance.PlaySound(AudioManager.Instance.hitRock);

        }
    }
    IEnumerator changematerial()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.material = defaultMaterial;
    }
}
