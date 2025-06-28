using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/Powerup")]
public class Powerup : ScriptableObject
{
    public bool isActive;

    [SerializeField]
    protected PowerupStats duration;

    public float GetDuration()
    {
        return duration.GetValue();
    }
}
