namespace DependencyInjection.LifeTime.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }
    public interface ISingleton : IGuidGenerator
    {

    }

    public interface IScoped : IGuidGenerator
    {

    }

    public interface ITransient : IGuidGenerator { }

    public class Singleton : ISingleton
    {
        private Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }

    public class Scoped : IScoped
    {
        private Guid guid;
        public Scoped()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }

    public class Transient : ITransient
    {
        private Guid guid;
        public Transient()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }

    public class GuidService
    {
        public ISingleton Singleton { get; set; }
        public IScoped Scoped { get; set; }
        public ITransient Transient { get; set; }

        public GuidService(ISingleton singleton, IScoped scoped, ITransient transient)
        {
            Singleton = singleton;
            Scoped = scoped;
            Transient = transient;
        }
    }

}
