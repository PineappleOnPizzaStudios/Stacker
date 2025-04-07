using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text scoreText;
    public int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist across scenes
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
