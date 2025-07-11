using UnityEngine;

[CreateAssetMenu(fileName = "PowerupStats", menuName = "Scriptable Objects/PowerupStats")]
public class PowerupStats : ScriptableObject
{
    //[SerializeField]
    //private float value;

    [SerializeField]
    private float[] values;

    public float GetValue(int level = 1)
    {
        if (level < 0)
            return values[0];
        else if (level >= values.Length)
            return values[values.Length - 1];
        else
            return values[level - 1];
    }
}
