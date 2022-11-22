using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystickBg;
    public RectTransform joystick;

    [Range(0, 1000)] 
    public float maxDisplacement = 30;

    private JoystickControl control;

    private void Start()
    {
        joystickBg.gameObject.SetActive(false);
        control = new JoystickControl(joystick, maxDisplacement);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickBg.gameObject.SetActive(true);
        joystickBg.position = eventData.position;

        control.PointerDown(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        control.Dragging(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBg.gameObject.SetActive(false);

        control.PointerUp();
    }
}
