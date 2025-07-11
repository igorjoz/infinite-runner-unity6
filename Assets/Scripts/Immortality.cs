using UnityEngine;

[CreateAssetMenu(fileName = "Immortality", menuName = "Powerup/Immortality")]
public class Immortality : Powerup
{
    [SerializeField]
    private PowerupStats speedBoost;
    public float timeLeft;

    public float GetSpeedBoost()
    {
        return speedBoost.GetValue(currentLevel);
    }
}
