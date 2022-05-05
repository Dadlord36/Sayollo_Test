using System.Threading.Tasks;

namespace Factories.TaskFactories
{
    public static class TasksFactories
    {
        public static TaskFactory MainThreadTaskFactory { get; } = new(TaskScheduler.FromCurrentSynchronizationContext());
    }
}