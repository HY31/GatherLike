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
        // ���콺 ��ġ�� �����Ͽ� aimDirection�� ����մϴ�.
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        Vector2 aimDirection = (worldPos - (Vector2)transform.position).normalized;

        // CallLookEvent �޼��带 ȣ���Ͽ� aimDirection�� �����մϴ�.
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
