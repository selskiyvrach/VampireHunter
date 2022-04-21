namespace Selskiyvrach.VampireHunter.Combat.Weapons
{
    public readonly struct Damage
    {
        private readonly float _value;
        public float Value => _value;

        public Damage(float value)
        {
            _value = value;
        }
    }
}