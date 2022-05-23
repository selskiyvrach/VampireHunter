namespace Selskiyvrach.VampireHunter.Model.SceneLoading
{
    public struct SceneID
    {
        public SceneID(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}