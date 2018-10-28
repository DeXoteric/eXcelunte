using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//TODO remove, save for later use
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image joystickImage;

    [SerializeField] private float joystickRadius;

    public Vector2 InputDirection { get; set; }

    private void Start()
    {
        InputDirection = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = position.x / backgroundImage.rectTransform.sizeDelta.x;
            position.y = position.y / backgroundImage.rectTransform.sizeDelta.y;

            float x = (backgroundImage.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (backgroundImage.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

            InputDirection = new Vector2(x, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            joystickImage.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (backgroundImage.rectTransform.sizeDelta.x / 3), InputDirection.y * (backgroundImage.rectTransform.sizeDelta.y / 3)) * joystickRadius;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }
}