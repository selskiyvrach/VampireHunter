namespace Selskiyvrach.VampireHunter.View
{
    public class TriggerCockedAnimationCallbackReceiver : AnimationCallbackReceiver
    {
        private void OnTriggerCocked() => InvokeInternal();
    }
}