namespace Selskiyvrach.VampireHunter.Model.Spread
{
    public class StaticSpread : SpreadTerm
    {
        public StaticSpread(float value) => 
            Value = value;

        public StaticSpread SetValue(float value)
        {
            Value = value;
            return this;
        }
    }
}