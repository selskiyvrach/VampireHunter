namespace Selskiyvrach.VampireHunter.Model.Combat
{
    public readonly struct Damage
    {
        public float Value { get; }
        
        public Damage(float value) => 
            Value = value;
    }
}