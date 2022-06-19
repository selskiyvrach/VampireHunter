namespace Selskiyvrach.VampireHunter.Gameplay.Model.Damaging
{
    public readonly struct Damage
    {
        public float Value { get; }
        
        public Damage(float value) => 
            Value = value;
    }
}