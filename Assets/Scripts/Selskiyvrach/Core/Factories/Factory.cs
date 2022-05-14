namespace Selskiyvrach.Core.Factories
{
    public interface IFactory
    {
        object CreateAsObject();
    }
    
    public interface IFactory<T> : IFactory
    {
        T Create();
    }
    
    public abstract class Factory : IFactory
    {
        public abstract object CreateAsObject();
    }

    public abstract class Factory<T> : Factory, IFactory<T>
    {
        public abstract T Create();

        public override object CreateAsObject() =>
            Create();
    }
}