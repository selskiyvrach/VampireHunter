using Selskiyvrach.Core.Factories;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class GunFactory : IFactory<IGun>
    {
        private readonly IFactory<ISight> _sightFactory;
        private readonly IFactory<IMagazine> _magazineFactory;
        private readonly IFactory<ITrigger> _triggerFactory;

        public GunFactory(IFactory<ISight> sightFactory, IFactory<IMagazine> magazineFactory, IFactory<ITrigger> triggerFactory)
        {
            _sightFactory = sightFactory;
            _magazineFactory = magazineFactory;
            _triggerFactory = triggerFactory;
        }

        public IGun Create() =>
            new Gun(
                _magazineFactory.Create(), 
                _triggerFactory.Create(), 
                _sightFactory.Create());

        public object CreateAsObject() => 
            Create();
    }
}