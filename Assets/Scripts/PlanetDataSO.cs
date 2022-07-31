using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Scriptable Objects/Planet Scriptable Object", order = 1)]
public class PlanetDataSO : CelestialDataSO
{
    public long Population;

    public override void InitializeCelestial(CelestialDataHandler celestialDataHandler)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return $"{CelestialName} - {CelestialDescription} - {Radius} - {Population}";
    }

}
