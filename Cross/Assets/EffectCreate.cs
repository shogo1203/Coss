using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreate : MonoBehaviour
{
    [SerializeField] GameObject par;
    [SerializeField] AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SEManager.Instance.OneShot(clip);
            Instantiate(par, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
