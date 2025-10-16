using UnityEngine;

public class PhaserWeapon : MonoBehaviour
{
    public static PhaserWeapon Instance;
    [SerializeField] private ObjectPooller BulletPool;

    public float speed;
    public int damage;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Shoot()
    {
       
       GameObject bullet =  BulletPool.GetObject();
        AudioManager.Instance.PlayModifiedSound(AudioManager.Instance.shoot);
        bullet.transform.position = transform.position; 
        bullet.SetActive(true);  

    }
}
