using UnityEngine;

[CreateAssetMenu(fileName = "PowerupStats", menuName = "Scriptable Objects/PowerupStats")]
public class PowerupStats : ScriptableObject
{
    [SerializeField]
    private float value;

    public float GetValue()
    {
        return value;
    }
}
