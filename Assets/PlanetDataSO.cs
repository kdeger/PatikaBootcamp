using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Scriptable Objects/Planet Scriptable Object", order = 1)]
public class PlanetDataSO : CelestialDataSO
{
    public long Population;
    public List<MoonDataSO> Moons;

    public override string ToString()
    {
        return $"{CelestialName} - {CelestialDescription} - {Radius} - {Population}";
    }

    public void GenerateMoons(CelestialDataHandler celestialDataHandler)
    {
        foreach (MoonDataSO moon in Moons)
        {
            moon.InstantiateMoon(celestialDataHandler);
        }
    }

    public override void InitializeCelestial(CelestialDataHandler celestialDataHandler)
    {
        GenerateMoons(celestialDataHandler);
    }

}
