using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public float swingSpeed = 2f;     // Speed of the swing
    public float swingRange = 3f;     // How far to the left and right it swings

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * swingSpeed) * swingRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}

