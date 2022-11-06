namespace Asteroids.GameStates
{
    public class StateManager
    {
        private GameState _state;
        private State   _start;
        private State _ingame;
        private State _end;
        private State _currentState;

        public StateManager()
        {
            _state = GameState.Start; //initialize gamestate
            _start = new StartState();
            _ingame = new IngameState();
            _end = new EndState();
            _currentState = new StartState();
        }

        public void Update()
        {
            _state =  _currentState.ChangeState();
            switch (_state)
            {
                case GameState.Start:
                    _currentState = _start;
                    break;
                case GameState.Ingame:
                    _currentState = _ingame;
                    break;
                case GameState.End:
                    _currentState = _end;
                    break;
            }
            _currentState.Update();

        }
    }
}
