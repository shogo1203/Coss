using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGround;
    [SerializeField] Transform createPos;
    [SerializeField] GameObject par;
    [SerializeField] GameObject par2;
    [SerializeField] PlayerInput mInput;
    [SerializeField] AudioClip clip;

    public bool IsGround { get { return isGround; } }

    // Use this for initialization
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && mInput.IsJump)
        {
            SEManager.Instance.OneShot(clip);
            Vector3 hitPos = createPos.position;
            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
            }
            Instantiate(par, hitPos, Quaternion.identity);
            mInput.IsJump = false;
        }
    }
}
