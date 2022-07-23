using UnityEngine;
using UnityEngine.UI;

public class SliderOnValueChanged : MonoBehaviour
{
        Scrollbar scrollBar;
    private void Awake() {
        Scrollbar scrollBar = GetComponent<Scrollbar>();

        scrollBar.onValueChanged.AddListener(delegate {
            OnValueChanged();
        });
    }

    public void OnValueChanged() {
        Debug.Log("Value: " + scrollBar.value);
    }

}
