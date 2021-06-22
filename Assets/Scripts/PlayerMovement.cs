using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    Vector3 m_Movement;
    Animator m_Animator;
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();
        bool horizontalInput = !Mathf.Approximately(horizontal, 0); // check if moving or not.
        bool verticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = horizontalInput || verticalInput;
        m_Animator.SetBool("isWalking", isWalking);
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0);
        m_Rotation = Quaternion.LookRotation(desiredForward);
     }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
