using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhHandler : MonoBehaviour
{
    [SerializeField, Range(-2, 2)] private int offset;
    private const int Clamp = 9;
    [SerializeField] private InputActionReference holdInputActionReference, mousePosInputActionReference;
    private InputAction HoldInputAction => holdInputActionReference.action;
    private InputAction MousePosInputAction => mousePosInputActionReference.action;
    private bool _hold;
    public UnityEvent<int> onRelease;

    [SerializeField] private Texture2D cursor;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private Slider counterSlider;
    
    private GameObject eventSystem;

    private bool _isOverDna;

    public void SetOverDna(bool isOverDna) => _isOverDna = isOverDna;

    private void Awake()
    {
        MousePosInputAction.Enable();
        eventSystem = EventSystem.current.gameObject;
    }

    public void ListenHold() {
        HoldInputAction.Enable();
        HoldInputAction.performed += OnHold;
        HoldInputAction.canceled += OnRelease;
        SetCursor(cursor);
    }

    private void OnRelease(InputAction.CallbackContext obj)
    {
        eventSystem.SetActive(true);
        counterSlider.gameObject.SetActive(false);
        SetCursor(null);
        _hold = false;
    }

    private void OnHold(InputAction.CallbackContext obj) {
        if(!_isOverDna) return;
        eventSystem.SetActive(false);
        _hold = true;
        counterSlider.gameObject.SetActive(true);
        counterText.text = "0";
        counterSlider.value = 0;
        StartCoroutine(HoldCoroutine());
    }

    public void OnDisable() {
        HoldInputAction.performed -= OnHold;
        HoldInputAction.Disable();
    }

    private IEnumerator HoldCoroutine()
    {
        float time = 0;
        int value = 0;
        while (_hold) {
            time += Time.deltaTime;
            if (time > 1) {
                time = 0;
                value += offset;
            }
            if (value > Clamp) value = Clamp;
            else counterSlider.value = time;
            counterText.text = value.ToString();
            counterSlider.transform.position = MousePosInputAction.ReadValue<Vector2>();
            yield return null;
        }
        onRelease?.Invoke(value);
    }

    private void SetCursor(Texture2D texture) {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
    
}