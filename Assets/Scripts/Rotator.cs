using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.instance.inGame)
        {
            return;
        }
        
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
