using UnityEngine;

public class PhaserBullet : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(PhaserWeapon.Instance.speed, 0f) * Time.deltaTime;
    
    if(transform.position.x > 9f)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Critter") || collision.gameObject.CompareTag("Boss"))
        {

            gameObject.SetActive(false);

        }
    }
}
