namespace DevToolz.Library.Extensions;

public static class TaskExtensions
{
    public static TResult Sync<TResult>( this Task<TResult> tarefa )
        => Task.Run( () => tarefa ).GetAwaiter().GetResult();

    public static void Sync( this Task tarefa )
        => Task.Run( () => tarefa ).GetAwaiter().GetResult();
}