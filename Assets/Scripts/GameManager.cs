using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float worldScrollingSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
