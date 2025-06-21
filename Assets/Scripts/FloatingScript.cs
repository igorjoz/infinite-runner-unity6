using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public float floatingHeight = 0.5f;

    private const int STEPS = 25;
    private bool up = true;
    private int count = 0;

    void FixedUpdate()
    {
        Vector3 move;

        if (up)
        {
            move = new Vector3(0f, floatingHeight / STEPS, 0f);
        }
        else
        {
            move = new Vector3(0f, -floatingHeight / STEPS, 0f);
        }

        count++;
        transform.position += move;

        if (count == STEPS)
        {
            up = !up;
            count = 0;
        }
    }
}
