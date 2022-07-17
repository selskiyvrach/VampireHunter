using System.Threading.Tasks;

namespace Selskiyvrach.Core.Lifecycle
{
    public interface IInitializable
    {
        Task Initialize();
    }

    public interface IResourceReleaser
    {
        Task ReleaseResources();
    }

    public interface IEnablable
    {
        void Enable();
        void Disable();
    }
}