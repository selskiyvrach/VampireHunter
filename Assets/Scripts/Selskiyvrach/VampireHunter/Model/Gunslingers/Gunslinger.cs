using Selskiyvrach.Core;
using Selskiyvrach.Core.Unity.Inputs;
using Selskiyvrach.VampireHunter.Model.Animations;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class Gunslinger : ITickable
    {
        private readonly Arsenal _arsenal = new Arsenal();
        private readonly Accuracy _accuracy = new Accuracy(80);
        
        private readonly Eyes _eyes;
        private readonly AnimationsPlayer _animator;
        private readonly ITouchInput _input;

        private Gun _gun;

        public Gunslinger(Eyes eyes, AnimationsPlayer animator, ITouchInput input)
        {
            _eyes = eyes;
            _animator = animator;
            _input = input;
        }

        public void Accept(IGunslingerVisitor visitor) =>
            visitor.Visit(_eyes, _arsenal, _accuracy, _animator, _gun);

        public void Tick(float deltaTime)
        {
            
        }
    }
}