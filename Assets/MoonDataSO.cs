using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moon", menuName = "Scriptable Objects/Moon Scriptable Object", order = 1)]
public class MoonDataSO : CelestialDataSO
{
    [SerializeField] GameObject _moonPrefab;
    [SerializeField] float _orbitRadius;

    private Transform _parentPlanet;
    private GameObject moon;
    public override string ToString()
    {
        return $"{CelestialName} - {CelestialDescription} - {Radius} - {_moonPrefab.name}";
    }

    public void InstantiateMoon(CelestialDataHandler celestialDataHandler)
    {
        _orbitRadius -= 100;

        moon = Instantiate(_moonPrefab);
        _parentPlanet = celestialDataHandler.gameObject.transform;
    }

    private void Update() 
    {
        if (_parentPlanet != null)
            moon.transform.RotateAround(_parentPlanet.transform.position, Vector3.up , Time.deltaTime * _orbitRadius);
    }

    public override void InitializeCelestial(CelestialDataHandler celestialDataHandler)
    {
        throw new System.NotImplementedException();
    }
}
