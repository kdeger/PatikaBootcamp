using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] LevelDataSO levelData;

    void Start()
    {
        InstantiatePrefabs();
    }
    private void InstantiatePrefabs()
    {
        foreach (var starGroup in levelData.StarGroups)
        {
            var star = Instantiate(starGroup.Star.CelestialPrefab, starGroup.StarPosition, Quaternion.identity);

            foreach (var planet in starGroup.Planets)
            {
                float randomTetha = Random.Range(0f, 360f);
                Vector3 randomOrbitPosition = star.transform.position + GetRandomPoisitionOnOrbit(randomTetha, planet.DistanceToStar);
                var planetObject = Instantiate(planet.Planet.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
                if (planetObject.GetComponent<CelestialMovement>() != null)
                {
                    planetObject.GetComponent<CelestialMovement>().TargetObject = star.transform;
                }
                foreach (var moon in planet.Moons)
                {
                    randomTetha = Random.Range(0f, 360f);
                    randomOrbitPosition = planetObject.transform.position + GetRandomPoisitionOnOrbit(randomTetha, moon.DistanceToPlanet);
                    var moonObject = Instantiate(moon.Moon.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
                    moonObject.transform.parent = planetObject.transform;
                    if (moonObject.GetComponent<CelestialMovement>() != null)
                    {
                        moonObject.GetComponent<CelestialMovement>().TargetObject = planetObject.transform;
                    }
                }
            }
        }

    }

    private static Vector3 GetRandomPoisitionOnOrbit(float tetha, float radius)
    {
        return new Vector3(Mathf.Cos(tetha * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(tetha * Mathf.Deg2Rad) * radius);
    }
}
