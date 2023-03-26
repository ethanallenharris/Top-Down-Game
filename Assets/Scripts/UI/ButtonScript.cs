using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonHighlight;
    public Button button;
    public GameObject hidePanel;
    public GameObject showPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHighlight.active = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHighlight.active = false;
    }

    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    public virtual void ButtonClicked()
    {
        showPanel.active = true;
        hidePanel.active = false;
    }

}
