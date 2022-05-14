namespace Selskiyvrach.VampireHunter.Unity.Animations
{
    public class ShotAnimationCallbackReceiver : AnimationCallbackReceiver
    {
        private void OnShot() => InvokeInternal();
    }
}