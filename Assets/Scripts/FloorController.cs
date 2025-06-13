using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject floorTiles1, floorTiles2;
    public GameObject[] floorTiles;

    private void FixedUpdate()
    {
        if (!GameManager.instance.inGame)
        {
            return;
        }

        floorTiles1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
        floorTiles2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

        if (floorTiles2.transform.position.x < 0f)
        {
            //floorTiles1.transform.position += new Vector3(36f, 0f, 0f);
            int randomIndex = Random.Range(0, floorTiles.Length);
            var newFloorTile = Instantiate(floorTiles[randomIndex], floorTiles2.transform.position + new Vector3(18f, 0f, 0f), Quaternion.identity);

            Destroy(floorTiles1);

            //var temp = floorTiles1;
            floorTiles1 = floorTiles2;
            floorTiles2 = newFloorTile;
        }
    }
}
