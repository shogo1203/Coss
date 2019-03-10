using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject par;
    [SerializeField] GameObject endCanvas;
    [SerializeField] AudioClip clip;
    bool isDead;

    // Use this for initialization
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (gameObject.transform.position.y <= -10)
            {
                SEManager.Instance.OneShot(clip);
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                isDead = true;
                Instantiate(par, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                GameManager.Instance.IsPlay = false;
                endCanvas.SetActive(true);
                GameManager.Instance.IsEnd = true;
            }
        }
    }
}
