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
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        energy = Maxenergy;
        UIController.Instance.SetMaxEnergy(energy, Maxenergy);
    }


    void Update()
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
        UIController.Instance.SetMaxEnergy(energy, Maxenergy);

    }

    private void OnBoostEnter()
    {
        if(energy > 10f)
        {
        animator.SetBool("boosting", true);
        boost = boostSpeed;
        boosting = true;

        }
    }
    private void OnBoostExit()
    {
        animator.SetBool("boosting", false);
        boost = 1f;
        boosting = false;
    }
}
