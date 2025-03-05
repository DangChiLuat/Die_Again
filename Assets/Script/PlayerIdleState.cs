using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    GameInput gameInput;

    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(player.moveDir.x !=0 || player.moveDir.z !=0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
