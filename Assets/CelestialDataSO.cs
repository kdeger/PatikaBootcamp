using UnityEngine;

public abstract class CelestialDataSO : ScriptableObject
{
    [SerializeField] string _celestialName;
    public string CelestialName { get { return _celestialName; }}
    public string CelestialDescription;
    public float Radius;

    public override string ToString()
    {
        return $"{CelestialName} - {CelestialDescription} - {Radius}";
    }

    public abstract void InitializeCelestial(CelestialDataHandler celestialDataHandler);
}
