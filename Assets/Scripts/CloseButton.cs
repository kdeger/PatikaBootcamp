using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject _parentPopup;

    private void Awake() 
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CloseParentPopup);
    }

    public void CloseParentPopup()
    {
        _parentPopup.SetActive(false);
    }

}
