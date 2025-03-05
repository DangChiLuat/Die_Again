using UnityEngine;

public class Player : Entity
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;
    public float gravity = 9.8f;

    private CharacterController characterController;


    private bool isWalking;
    public Vector3 moveDir;
    public float jumpForce;
    public Vector3 velocity;

    public bool IsWalking()
    {
        return isWalking;
    }



    // ham co the di chuyen
    public void HandleMovement()
    {
        Vector3 dir = gameInput.GetMovementVectorNormalized();
        moveDir = new Vector3(dir.x, 0, dir.y);

        velocity.x = moveDir.x;
        velocity.z = moveDir.z;

        if (moveDir.sqrMagnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
        if (characterController.enabled)
            characterController.Move(velocity * Time.deltaTime);
    }


    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        characterController = GetComponent<CharacterController>();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckGrounded();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.I))
        {
            velocity.y = jumpForce;
        }

        HandleMovement();
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.2f, groundLayer);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * 0.2f);
    }


}
