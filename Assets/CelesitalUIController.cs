using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelesitalUIController : MonoBehaviour
{
    private void Awake()
    {
        CelestialSelectionHandler.OnCelestialSelected += OnCelestialSelected;
    }
    private void OnDestroy() {
        CelestialSelectionHandler.OnCelestialSelected -= OnCelestialSelected;
    }

    void OnCelestialSelected(CelestialDataSO celestial)
    {
        Debug.Log(celestial.ToString());
    }


}
