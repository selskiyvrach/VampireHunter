namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns
{
    public readonly struct Recoil
    {
        public float Amount { get; }

        public Recoil(float amount) => 
            Amount = amount;
    }
}