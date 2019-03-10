using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float power;
    [SerializeField] GroundCheck check;
    [SerializeField] float limitPower;
    enum Direction { forward, back, right, left, }
    Direction dir;
    public bool IsJump;

    // Use this for initialization
    void Start()
    {
        dir = Direction.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlay)
        {
            Move();
            Jump();
        }
    }

    void Move()
    {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.z > -limitPower)
                rb.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (rb.velocity.z< limitPower)
                rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x < limitPower)
                rb.AddForce(Vector3.right * speed);
        }
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > -limitPower)
                rb.AddForce(Vector3.left * speed);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsJump)
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
            IsJump = true;
        }
    }
}
