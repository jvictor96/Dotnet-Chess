public class InMemoryKeyboard : IKeyboard
{
    private Queue<string> inputs = new Queue<string>();

    public void AddInput(string input)
    {
        inputs.Enqueue(input);
    }

    public string Read(string prompt)
    {
        return inputs.Dequeue();
    }
}