using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Language>().FromInstance(new Language()).AsSingle();
    }
}