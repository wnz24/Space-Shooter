using UnityEngine;
using UnityEngine.Experimental.Animations;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;
    //[SerializeField] float moveSpeed = 5f;
    public float boost = 1f;
    private float boostSpeed = 6f;
    [SerializeField] private float energy;
    [SerializeField] private float Maxenergy;
    [SerializeField] private float energyRegen;

    [SerializeField] private float health;
    [SerializeField] private float Maxhealth;

    public GameObject DestroyEffect;

    private bool boosting = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        energy = Maxenergy;
        UIController.Instance.SetMaxEnergy(energy, Maxenergy);
        health = Maxhealth;
        UIController.Instance.SetMaxHealth(health, Maxhealth);
    }


    void Update()
    {
        if(Time.timeScale > 0)
        {

            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            animator.SetFloat("moveX", moveX);
            animator.SetFloat("moveY", moveY);
            movement = new Vector2(moveX, moveY);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
            {
                OnBoostEnter();
            }
            else if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire2"))
            {
                OnBoostExit();
            }
        }
    }
    private void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(movement.x * boost, movement.y * boost) ;
        if (boosting)
        {
            if (energy >= 0.2f) energy -= 0.2f;
            else OnBoostExit();
        }
        else
        {
            if (energy < Maxenergy) energy += energyRegen;
        }
        if (UIController.Instance != null)
        {
            UIController.Instance.SetMaxEnergy(energy, Maxenergy);
        }
    }

    private void OnBoostEnter()
    {
        if(energy > 10f)
        {
        animator.SetBool("boosting", true);
        boost = boostSpeed;
        boosting = true;
            AudioManager.Instance.PlaySound(AudioManager.Instance.fire);

        }
    }
    public void OnBoostExit()
    {
        animator.SetBool("boosting", false);
        boost = 1f;
        boosting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
           
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        UIController.Instance.SetMaxHealth(health, Maxhealth);
        AudioManager.Instance.PlaySound(AudioManager.Instance.hit);

        if (health <= 0)
        {
            boost = 0f;
            gameObject.SetActive(false);
            Instantiate(DestroyEffect,transform.position, transform.rotation);
            AudioManager.Instance.PlaySound(AudioManager.Instance.ice);
            GameManager.Instance.GameOver();
        }
    }   
}
