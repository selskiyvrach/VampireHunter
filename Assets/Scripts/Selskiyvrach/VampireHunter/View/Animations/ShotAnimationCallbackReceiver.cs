namespace Selskiyvrach.VampireHunter.View
{
    public class ShotAnimationCallbackReceiver : AnimationCallbackReceiver
    {
        private void OnShot() => InvokeInternal();
    }
}