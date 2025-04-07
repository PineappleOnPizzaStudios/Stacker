using UnityEngine;
using UnityEngine.UI;

public class BlockStacker : MonoBehaviour
{
    private Rigidbody rb;
    public float snapThreshold = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            float xDiff = Mathf.Abs(transform.position.x - collision.transform.position.x);

            if (xDiff < snapThreshold)
            {
                Vector3 pos = transform.position;
                pos.x = collision.transform.position.x;
                transform.position = pos;

                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                rb.linearDamping = 5f;              // Add horizontal resistance
                rb.angularDamping = 5f;       // Add rotational resistance
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

                // Optional: Add satisfying sound or particles
                GameManager.Instance.AddScore(10);
                Debug.Log("Perfect stack!");
            }
            else
            {
                GameManager.Instance.AddScore(1);
            }
     
        }
    }
}

