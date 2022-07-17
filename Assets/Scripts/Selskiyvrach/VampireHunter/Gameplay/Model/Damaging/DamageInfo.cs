namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public struct DamageInfo
    {
        public float Amount { get; }

        public DamageInfo(float amount) => 
            Amount = amount;
    }
}