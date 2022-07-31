using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Celestials.UI
{
    public class PlanetUIManager : MonoBehaviour
    {
        [SerializeField] GameObject _planetInfoPopup;
        [SerializeField] GameObject _planetHealthUIObject;
        [SerializeField] float _planetHealth;
        [SerializeField] float _planetMaxHealth;
        private void OnMouseUpAsButton()
        {
            var currentEvent = EventSystem.current.IsPointerOverGameObject();

            if (currentEvent)
                return;

            _planetInfoPopup.SetActive(true);
            _planetInfoPopup.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;

            _planetHealthUIObject.SetActive(true);
            _planetHealthUIObject.GetComponent<HealthBarHandler>().CurrentHealthBar.GetComponent<Image>().fillAmount = _planetHealth / _planetMaxHealth;
        }
    }
}

