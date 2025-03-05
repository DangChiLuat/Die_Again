public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }


    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    // khoi tao trang thai moi cua nguoi choi
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}
