using UnityEngine;
using UnityEngine.EventSystems;

public class CelestialSelectionHandler : MonoBehaviour
{
    public static event System.Action<CelestialDataSO> OnCelestialSelected;
    private void OnMouseUpAsButton()
    {
        var currentEvent = EventSystem.current.IsPointerOverGameObject();

        if (currentEvent)
            return;

        OnCelestialSelected?.Invoke(GetComponent<CelestialDataHandler>().CelestialData);
    }
}
