using Artifacts.Factory;
using Buffs.Factory;
using CharacterInventory;
using CharacterInventory.ArtifactsProc;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Effects.Factory;
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
            BindInfrastructureServices();
            BindCommonServices();
            BindGameplayFactories();
            BindAssetManagementServices();
            BindGameplayServices();
            BindCameraProvider();
        }


        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }
        
        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IArtifactsProcService>().To<ArtifactsProcService>().AsSingle();
        }


        private void BindGameplayFactories()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IArtifactFactory>().To<ArtifactFactory>().AsSingle();
            Container.Bind<IBuffFactory>().To<BuffFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
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

        public void Initialize()
        {
            Container.Resolve<IStaticDataService>().LoadAll();
            Container.Resolve<ISceneLoader>().LoadScene(Scenes.SampleScene);
        }
    }
}