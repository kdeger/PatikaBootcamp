using UnityEngine;

public class CelestialDataHandler : MonoBehaviour
{
    public CelestialDataSO CelestialData;

    private void Awake()
    {
        InitializeSOData();
    }
    private void InitializeSOData()
    {
        CelestialData.InitializeCelestial(this);
    }
}