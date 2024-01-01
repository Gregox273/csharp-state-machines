using double_clutch;

Console.WriteLine("Use 'k' to depress clutch, 'i' to release clutch and number keys 1-4 to select a gear.");
Console.WriteLine("Press 'c' to exit.\n\n");

StateMachine stateMachine = new(State.Neutral);

ConsoleKey key;
do
{
    key = Console.ReadKey().Key;
    switch (key)
    {
        case ConsoleKey.K:
            stateMachine.RaiseEvent(Event.DepressClutch);
            break;
        case ConsoleKey.I:
            stateMachine.RaiseEvent(Event.ReleaseClutch);
            break;
        case ConsoleKey.D1:
            stateMachine.RaiseEvent(Event.SelectFirst);
            break;
        case ConsoleKey.D2:
            stateMachine.RaiseEvent(Event.SelectSecond);
            break;
        case ConsoleKey.D3:
            stateMachine.RaiseEvent(Event.SelectThird);
            break;
        case ConsoleKey.D4:
            stateMachine.RaiseEvent(Event.SelectFourth);
            break;
        default:
            /* Ignore key */
            break;
    }
} while (key != ConsoleKey.C);

Console.WriteLine("\nExiting...");