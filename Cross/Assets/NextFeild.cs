using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFeild : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] AudioClip clip;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SEManager.Instance.OneShot(clip);
            GameManager.Instance.IsPlay = false;
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<PlayerInput>().IsJump = true;
            var _rb = other.GetComponent<Rigidbody>();
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}
