using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        Destroy(gameObject,Animator.GetCurrentAnimatorStateInfo(0).length);
    }

   
}
