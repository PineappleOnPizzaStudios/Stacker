using UnityEngine;

public class Fall_Limiter : MonoBehaviour
{
    public Transform blockPosition;
    public GameObject blockPrefab;
    public float pushForce = 5f;
    public float rotAmount;
    public bool callBLOCK;
    private Rigidbody rb;
    bool goRight = false;
    bool goLeft = false;
    public float t;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (callBLOCK)
        {
            CallBlock(callBLOCK);
        }
        if (goRight)
        {
            Invoke("RotateTowardRight", 0.25f);
        }
        else if (goLeft)
        {
            Invoke("RotateTowardLeft", 0.25f);
        }
    }
    private void RotateTowardRight()
    {
        Vector3 direction = new(0, 0, -rotAmount);
        Quaternion newRot = Quaternion.Euler(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, t);
    }
    private void RotateTowardLeft()
    {
        Vector3 direction = new(0, 0, rotAmount);
        Quaternion newRot = Quaternion.Euler(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, t);
    }
    private void CallBlock(bool summoned)
    {
        summoned = false;
        if (summoned == false)
        {
            Vector3 transformRef = blockPosition.position;
            Instantiate(blockPrefab, transformRef, Quaternion.identity);
            callBLOCK = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoLeft"))
        {
            if (rb != null)
            {
                goLeft = true;
                goRight = false;

                rb.AddForce(Vector3.left * pushForce, ForceMode.Force);
                rb.linearVelocity = new Vector3(0, rb.position.y, rb.position.z);
            }
        }
        if (other.CompareTag("GoRight")) 
        {
            if (rb != null)
            {
                goRight = true;
                goLeft = false;

                rb.AddForce(-Vector3.left * pushForce, ForceMode.Force);
                rb.linearVelocity = new Vector3(0, rb.position.y, rb.position.z);
            }
        }
    }
}
