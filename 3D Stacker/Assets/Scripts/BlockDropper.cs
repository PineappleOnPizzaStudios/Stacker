using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    private Rigidbody rb;
    private BlockMover swing;
    private bool hasDropped = false;
    private bool hasSpawnedNext = false;

    public float velocityThreshold = 0.05f; // Sensitivity of "rest" detection

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        swing = GetComponent<BlockMover>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!hasDropped && Input.GetMouseButtonDown(0))
        {
            hasDropped = true;
            swing.enabled = false;
            rb.isKinematic = false;
        }

        if (hasDropped && !hasSpawnedNext && rb.linearVelocity.magnitude < velocityThreshold)
        {
            hasSpawnedNext = true;
            Invoke(nameof(SpawnNextBlock), 0.1f); // Optional: small delay
        }
    }

    void SpawnNextBlock()
    {
        BlockSpawner spawner = FindFirstObjectByType<BlockSpawner>();
        if (spawner != null)
        {
            spawner.SpawnNewBlock();
        }
    }
}

