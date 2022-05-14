namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public class TriggerCockedAnimationCallbackReceiver : AnimationCallbackReceiver
    {
        private void OnTriggerCocked() => InvokeInternal();
    }
}