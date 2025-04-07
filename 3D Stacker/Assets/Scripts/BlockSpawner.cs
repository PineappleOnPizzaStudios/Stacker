using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform currentSpawnPoint;
    public float blockHeight = 1f;

    public GameObject lastBlock;

    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        SpawnNewBlock();
    }

    public void SpawnNewBlock()
    {
        Vector3 spawnPos = currentSpawnPoint.position;

        if (lastBlock != null)
        {
            spawnPos.y = lastBlock.transform.position.y + blockHeight;
        }

        lastBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);

        if (cameraFollow != null)
        {
            cameraFollow.target = lastBlock.transform;
        }
    }
}
