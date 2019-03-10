using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStart : MonoBehaviour
{
    [SerializeField] Collider playerCol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTrigger"))
        {
            GameManager.Instance.IsPlay = true;
            playerCol.enabled = true;
        }
    }
}
