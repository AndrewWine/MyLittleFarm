using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joysticKnob;

    // Start is called before the first frame update

    [Header(" Setting ")]
    [SerializeField] private float moveFactor;
    private Vector3 clickedPosition;
    private bool canControl;
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl)
            ControlJoystick();
    }

    public void ClickOnJoystrickZoneCallback()
    {
        clickedPosition = Input.mousePosition;
        joystickOutline.position = clickedPosition;
        joysticKnob.position = joystickOutline.position;
        ShowJoystick();
        canControl = true;
    }    

    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
    }

    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        canControl = false;
    }

    private void ControlJoystick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;

        float moveMagnitude = direction.magnitude * moveFactor / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);

        Vector3 move = direction.normalized * 0.2f * moveMagnitude;

        Vector3 targetPosition = clickedPosition + move;

        joysticKnob.position = targetPosition;

    }
}
