using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    public enum SIDE { Left,Mid,Right}

    public float xValue;
    float NewXPos = 0f;
    public SIDE m_Side = SIDE.Mid;
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Animator animator;

    public Collider col;

    [SerializeField]
    private float speedAuto;

    private bool jumped=false;

    [SerializeField]private AudioSource Jump;
    [SerializeField]private AudioSource Dash;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedAuto;
        if(Input.GetKeyDown(KeyCode.A)) 
        { 
            if(m_Side == SIDE.Mid)
            {
                NewXPos = -xValue;
                m_Side = SIDE.Left;
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = xValue;
                m_Side = SIDE.Right;
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }
        transform.position = new Vector3(NewXPos, transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.S) && (!jumped))
        {
            animator.SetBool("GoDown", true);
            Dash.Play();

        }
        else
            animator.SetBool("GoDown", false);

        if (Input.GetKeyDown(KeyCode.Space) && (transform.position.y < 1.5f))
        {
            Jump.Play();
            animator.SetBool("isRunning", true);
            rb.AddForce(Vector3.up, ForceMode.Impulse);
            jumped = true;
        } else
            animator.SetBool("isRunning", false);
            jumped=false;

        
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
