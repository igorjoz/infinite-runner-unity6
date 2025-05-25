using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject floorTiles1, floorTiles2;

    private void FixedUpdate()
    {
        floorTiles1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
        floorTiles2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

        if (floorTiles2.transform.position.x < 0f)
        {
            floorTiles1.transform.position += new Vector3(36f, 0f, 0f);

            var temp = floorTiles1;
            floorTiles1 = floorTiles2;
            floorTiles2 = temp;
        }
    }
}
