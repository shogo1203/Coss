using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    [SerializeField] GameObject par;
    [SerializeField] GameObject par2;
    [SerializeField] GameObject clearCanvas;
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
            var rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            other.gameObject.SetActive(false);
            par.SetActive(true);
            Instantiate(par2, gameObject.transform.position, Quaternion.identity);
            GameManager.Instance.IsPlay = false;
            GameManager.Instance.IsClear = true;
            clearCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}
