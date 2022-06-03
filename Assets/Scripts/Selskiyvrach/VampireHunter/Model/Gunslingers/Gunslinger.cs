using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger
    {
        private readonly Arsenal _arsenal = new Arsenal();
        private readonly Accuracy _accuracy = new Accuracy(80);
        
        private readonly Eyes _eyes;
        private readonly AnimationsPlayer _animator;
        
        private Gun _gun;

        public Gunslinger(Eyes eyes, AnimationsPlayer animator)
        {
            _eyes = eyes;
            _animator = animator;
            _gun = _arsenal.GetGun(0);
        }

        public void Accept(IGunslingerVisitor visitor) =>
            visitor.Visit(_eyes, _arsenal, _accuracy, _animator, _gun);
    }
}