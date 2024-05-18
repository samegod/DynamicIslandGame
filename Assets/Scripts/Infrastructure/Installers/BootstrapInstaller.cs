using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Enemies.Factory;
using Infrastructure.AssetManagement;
using Infrastructure.Identifiers;
using Infrastructure.Loading;
using Infrastructure.StaticData;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindInfrastructureServices();
            BindGameplayFactories();
            BindUIService();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            BindGameplayServices();
            BindCameraProvider();
        }

        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }

        private void BindGameplayFactories()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindSystemFactory()
        {
        }

        private void BindInputService()
        {
        }

        private void BindUIService()
        {
        }

        public void Initialize()
        {
            Container.Resolve<IStaticDataService>().LoadAll();
            Container.Resolve<ISceneLoader>().LoadScene(Scenes.Meadow);
        }
    }
}