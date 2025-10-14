using UnityEngine;

public class MenuParallex : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    float width;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        width = sprite.texture.width / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed  * Time.deltaTime;
        transform.position += new Vector3(moveX, 0);
        if (Mathf.Abs(transform.position.x) - width > 0)
        {
            transform.position = new Vector3(0, transform.position.y);
        }
    }
}
