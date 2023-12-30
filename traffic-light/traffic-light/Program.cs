State state = State.Green;

Console.WriteLine("Press 'e' to exit, or any other key to begin.");

while (Console.ReadKey().Key != ConsoleKey.E)
{
    Console.WriteLine("\n");
    PrintLight(state);

    Thread.Sleep(1000);

    state = ChangeState(state, Input.Stop);

    MoveCursorBack();
    PrintLight(state);

    for (int i = 0; i < 3; i++)
    {
        Thread.Sleep(1000);

        state = ChangeState(state, Input.Tick);

        MoveCursorBack();
        PrintLight(state);
    }

    Console.WriteLine("\nPress 'e' to exit, or any other key to begin.");
}
Console.WriteLine("");

static void PrintLight(State state)
{
    switch (state)
    {
        case State.Green:
            Console.WriteLine("[o]");
            Console.WriteLine("[o]");
            Console.WriteLine("[#]");
            break;

        case State.Amber:
            Console.WriteLine("[o]");
            Console.WriteLine("[#]");
            Console.WriteLine("[o]");
            break;

        case State.Red:
            Console.WriteLine("[#]");
            Console.WriteLine("[o]");
            Console.WriteLine("[o]");
            break;

        case State.Red_Amber:
            Console.WriteLine("[#]");
            Console.WriteLine("[#]");
            Console.WriteLine("[o]");
            break;
        default:
            throw new NotImplementedException();
    };
}

static void MoveCursorBack()
{
    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 3);
}

static State ChangeState(State current, Input input) =>
    (current, input) switch
    {
        (State.Green, Input.Tick) => State.Green,
        (State.Green, Input.Stop) => State.Amber,
        (State.Amber, Input.Tick) => State.Red,
        (State.Amber, Input.Stop) => State.Amber,
        (State.Red, Input.Tick) => State.Red_Amber,
        (State.Red, Input.Stop) => State.Red,
        (State.Red_Amber, Input.Tick) => State.Green,
        (State.Red_Amber, Input.Stop) => State.Red_Amber,
        _ => throw new NotSupportedException(
            $"{current} has no transition on {input}")
    };

enum State { Red, Red_Amber, Green, Amber }
enum Input { Stop, Tick }