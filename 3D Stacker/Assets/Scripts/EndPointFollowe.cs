using UnityEngine;

public class EndPointFollowe : MonoBehaviour
{
    public BlockSpawner blockSpawner;
    void Update()
    {
        if (blockSpawner.lastBlock != null)
        {
            transform.SetParent(blockSpawner.lastBlock.transform);
            transform.position = blockSpawner.lastBlock.transform.position;
        }
    }
}
