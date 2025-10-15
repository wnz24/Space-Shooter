using UnityEngine;

public class PhaserBullet : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(PhaserWeapon.Instance.speed, 0f) * Time.deltaTime;
    
    if(transform.position.x > 9f)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            Destroy(gameObject);

        }
    }
}
