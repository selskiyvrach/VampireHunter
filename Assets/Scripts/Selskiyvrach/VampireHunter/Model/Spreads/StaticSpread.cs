namespace Selskiyvrach.VampireHunter.Model.Spreads
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