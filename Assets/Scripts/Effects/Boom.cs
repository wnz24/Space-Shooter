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

    private void Update()
    {
        float moveX = (GameManager.Instance.worldSpeed * PlayerController.Instance.boost) * Time.deltaTime;
        transform.position += new Vector3(moveX, 0);
    }
}
