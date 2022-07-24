using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level Data/Level", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public List<StarGroup> StarGroups;
}

[System.Serializable]
public class PlanetData
{
    public PlanetDataSO Planet;
    public float DistanceToStar;
    public List<MoonData> Moons;
}

[System.Serializable]
public class MoonData
{
    public MoonDataSO Moon;
    public float DistanceToPlanet;
}

[System.Serializable]
public class CelestialData
{
    public CelestialDataSO Celestial;
    public float DistanceToParentCelestial;
}

[System.Serializable]
public class StarGroup
{
    public StarDataSO Star;
    public Vector3 StarPosition;
    public List<PlanetData> Planets;
}
