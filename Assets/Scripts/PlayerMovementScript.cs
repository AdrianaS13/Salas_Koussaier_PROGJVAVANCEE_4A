using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Animator animator;

    public Collider col;

    [SerializeField]
    private float speedAuto;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedAuto;

        if (Input.GetKeyDown(KeyCode.S))
            animator.SetBool("GoDown", true);
        else
            animator.SetBool("GoDown", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isRunning", true);
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        } else
            animator.SetBool("isRunning", false);
    }

    public void RemoveCollider()
    {
        col.enabled = false;
        rb.useGravity = false;
    }
    public void AddCollider()
    {
        col.enabled = true;
        rb.useGravity = true;
    }
    
}
