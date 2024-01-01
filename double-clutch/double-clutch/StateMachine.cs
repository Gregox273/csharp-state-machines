namespace double_clutch
{

    public class StateMachine
    {
        private State _state;

        public StateMachine(State initialState)
        {
            _state = initialState;
            PrintState(_state);
        }

        public void RaiseEvent(Event evt)
        {
            switch (_state, evt)
            {
                case (State.Neutral, Event.DepressClutch):
                    _state = State.Engaging;
                    break;
                case (State.Engaging, Event.ReleaseClutch):
                    _state = State.Neutral;
                    break;
                case (State.Engaging, Event.SelectFirst):
                case (State.EngageSecond, Event.SelectFirst):
                case (State.EngageThird, Event.SelectFirst):
                case (State.EngageFourth, Event.SelectFirst):
                    _state = State.EngageFirst;
                    break;
                case (State.Engaging, Event.SelectSecond):
                case (State.EngageFirst, Event.SelectSecond):
                case (State.EngageThird, Event.SelectSecond):
                case (State.EngageFourth, Event.SelectSecond):
                    _state = State.EngageSecond;
                    break;
                case (State.Engaging, Event.SelectThird):
                case (State.EngageFirst, Event.SelectThird):
                case (State.EngageSecond, Event.SelectThird):
                case (State.EngageFourth, Event.SelectThird):
                    _state = State.EngageThird;
                    break;
                case (State.Engaging, Event.SelectFourth):
                case (State.EngageFirst, Event.SelectFourth):
                case (State.EngageSecond, Event.SelectFourth):
                case (State.EngageThird, Event.SelectFourth):
                    _state = State.EngageFourth;
                    break;
                case (State.EngageFirst, Event.ReleaseClutch):
                    _state = State.First;
                    break;
                case (State.EngageSecond, Event.ReleaseClutch):
                    _state = State.Second;
                    break;
                case (State.EngageThird, Event.ReleaseClutch):
                    _state = State.Third;
                    break;
                case (State.EngageFourth, Event.ReleaseClutch):
                    _state = State.Fourth;
                    break;
                case (State.First, Event.DepressClutch):
                case (State.Second, Event.DepressClutch):
                case (State.Third, Event.DepressClutch):
                case (State.Fourth, Event.DepressClutch):
                    _state = State.Disengaging;
                    break;
                case (State.Disengaging, Event.ReleaseClutch):
                    _state = State.Neutral;
                    break;
                default:
                    /* do nothing */
                    break;
            }

            PrintState(_state);
        }

        private static void PrintState(State state)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            switch (state)
            {
                case State.Neutral:
                    Console.WriteLine("[N]");
                    break;
                case State.First:
                    Console.WriteLine("[1]");
                    break;
                case State.Second:
                    Console.WriteLine("[2]");
                    break;
                case State.Third:
                    Console.WriteLine("[3]");
                    break;
                case State.Fourth:
                    Console.WriteLine("[4]");
                    break;
                case State.EngageFirst:
                    Console.WriteLine("[N->1]");
                    break;
                case State.EngageSecond:
                    Console.WriteLine("[N->2]");
                    break;
                case State.EngageThird:
                    Console.WriteLine("[N->3]");
                    break;
                case State.EngageFourth:
                    Console.WriteLine("[N->4]");
                    break;
                case State.Engaging:
                    Console.WriteLine("[N->]");
                    break;
                case State.Disengaging:
                    Console.WriteLine("[->N]");
                    break;
            }
        }
    }

    public enum State { Neutral, First, Second, Third, Fourth, EngageFirst, EngageSecond, EngageThird, EngageFourth, Engaging, Disengaging }
    public enum Event { DepressClutch, ReleaseClutch, SelectFirst, SelectSecond, SelectThird, SelectFourth }
}