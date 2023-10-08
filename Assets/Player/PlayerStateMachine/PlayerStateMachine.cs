using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    // Reference variables
    CharacterController _controller;
    Animator _animator;
    PlayerInput _playerInput;
    [SerializeField]
    Transform _playerCamera;
    Transform _playerTransform;

    // State variables
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    // Getters and Setters
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public CharacterController Controller { get { return _controller; } }
    public int JumpCount { get { return _jumpCount; } set { _jumpCount = value; } }
    public bool IsJumpPressed { get { return _isJumpPressed; } }
    public bool IsJumping { set { _isJumping = value; } }
    public bool RequireNewJumpPress { get { return _requireNewJumpPress; } set { _requireNewJumpPress = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } }
    public bool IsRunPressed { get { return _isRunPressed; } }
    public float CurrentMovementY { get { return _currentMovement.y; } set { _currentMovement.y = value; } }
    public float AppliedMovementX { get { return _appliedMovement.x; } set { _appliedMovement.x = value; } }
    public float AppliedMovementY { get { return _appliedMovement.y; } set { _appliedMovement.y = value; } }
    public float AppliedMovementZ { get { return _appliedMovement.z; } set { _appliedMovement.z = value; } }
    public float InitialJumpVelocity { get { return _initialJumpVelocity; } set { _initialJumpVelocity = value; } }
    public float RunMultiplier { get { return _runMultiplier; } }
    public float WalkSpeed { get { return _walkSpeed; } set { _walkSpeed = value; } }
    public float GroundedGravity { get { return _groundedGravity; } }
    public float Gravity { get { return _gravity; } set { _gravity = value; } }
    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } }
    public Transform PlayerTransform { get { return _playerTransform; } }

    // Player Input Variables
    Vector2 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _appliedMovement;
    bool _isMovementPressed;
    bool _isRunPressed;

    // Camera Input Variables
    Vector2 _currentCameraInput;
    float _cameraPitch = 0.0f;

    // Constants
    [Header("Movement Variables")]
    [SerializeField]
    float _runMultiplier;
    [SerializeField]
    float _walkSpeed;
    [Header("Camera Variables")]
    [SerializeField]
    float _sensitivity;
    int _zero = 0;

    // Gravity variables
    float _gravity = -9.81f;
    float _groundedGravity = -0.5f;

    // Jump variables
    bool _isJumpPressed;
    bool _requireNewJumpPress = false;
    float _initialJumpVelocity;
    float _maxJumpHeight = 4.0f;
    float _maxJumpTime = .75f;
    bool _isJumping = false;
    int _jumpCount = 0;

    // Awake is called before start
    private void Awake()
    {
        // Set reference variables
        _playerInput = new PlayerInput();
        _controller = GetComponent<CharacterController>();
        _playerTransform = gameObject.transform;

        // Setup State
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();

        // Set Input callbacks
        _playerInput.CharacterControls.Movement.started += OnMovementInput;
        _playerInput.CharacterControls.Movement.canceled += OnMovementInput;
        _playerInput.CharacterControls.Movement.performed += OnMovementInput;
        _playerInput.CharacterControls.Camera.started += OnCameraInput;
        _playerInput.CharacterControls.Camera.canceled += OnCameraInput;
        _playerInput.CharacterControls.Camera.performed += OnCameraInput;
        _playerInput.CharacterControls.Sprint.started += OnRun;
        _playerInput.CharacterControls.Sprint.canceled += OnRun;
        _playerInput.CharacterControls.Jump.started += OnJump;
        _playerInput.CharacterControls.Jump.canceled += OnJump;

        SetupJumpVariables();
    }

    void SetupJumpVariables()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
        _currentState.UpdateStates();
        _controller.Move(_appliedMovement * Time.deltaTime);
        Debug.Log(transform.forward);
    }

    public Vector3 CalculateDirectionalMovment(float speed)
    {
        Vector3 _xMovement = transform.forward * _currentMovementInput.y;
        Vector3 _zMovement = transform.right * _currentMovementInput.x;

        Vector3 _combinedMovement = _xMovement + _zMovement;

        return _combinedMovement *= speed;
    }

    void HandleCameraMovement()
    {
        _cameraPitch -= _currentCameraInput.y * _sensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90.0f);
        _playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        transform.Rotate(Vector3.up * _currentCameraInput.x * _sensitivity);
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _isMovementPressed = _currentMovementInput.x != _zero || _currentMovementInput.y != _zero;
    }

    void OnCameraInput(InputAction.CallbackContext context)
    {
        _currentCameraInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        _requireNewJumpPress = false;
    }

    void OnRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    void OnEnable()
    {
        _playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        _playerInput.CharacterControls.Disable();
    }
}
