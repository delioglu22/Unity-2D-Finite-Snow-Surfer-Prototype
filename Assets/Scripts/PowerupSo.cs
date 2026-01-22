using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSo")]
public class PowerupSo : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float time;

    public string GetpowerupType()
    {
        return powerupType;
    }
    public float GetvalueChange()
    {
        return valueChange;
    }
    public float Gettime()
    {
        return time;
    }
}
