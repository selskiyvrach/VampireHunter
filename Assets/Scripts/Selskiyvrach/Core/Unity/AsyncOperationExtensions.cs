using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Selskiyvrach.Core.Unity
{
    public static class AsyncOperationExtensions
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOperation)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            Task task = taskCompletionSource.Task;
            if (asyncOperation.isDone) taskCompletionSource.SetResult(true);
            else asyncOperation.completed += operation => taskCompletionSource.SetResult(true);
            return task.GetAwaiter();
        }
    }
}