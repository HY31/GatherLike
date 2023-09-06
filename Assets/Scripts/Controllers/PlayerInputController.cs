using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerInputController : CharacterController
{
    private Camera _camera;
    [SerializeField] private SpriteRenderer characterRenderer;


    private void Awake()
    {
        _camera = Camera.main;
        
    }
    private void Start()
    {
        OnLookEvent += OnAim;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        

    }
    public void OnLook(InputValue value)
    {
        // 마우스 위치를 감지하여 aimDirection을 계산합니다.
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        Vector2 aimDirection = (worldPos - (Vector2)transform.position).normalized;

        // CallLookEvent 메서드를 호출하여 aimDirection을 전달합니다.
        CallLookEvent(aimDirection);
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        characterRenderer.flipX = direction.x < 0f;
    }
}
