using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using MvvmCross.Demo.Core;

namespace MvvmCross.Demo.ViewModels
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IOmdbApi, OmdbApi>();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}