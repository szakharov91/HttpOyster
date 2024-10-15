using Caliburn.Micro;
using HttpOyster.UI.ViewModels;
using HttpOyster.UI.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HttpOyster.UI;

public class Bootstrapper: BootstrapperBase
{
    private IKernel? services;

    public Bootstrapper() => Initialize();

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.Empty, default(PropertyChangedCallback), null));

        DisplayRootViewForAsync<MainViewModel>();
    }

    protected override void Configure()
    {
        base.Configure();

        services = new StandardKernel();

        services.Bind<MainViewModel>().ToSelf().InSingletonScope();
        services.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();     // Менеджер окон
    }

    protected override object GetInstance(Type service, string key)
    {
        if (service == null)
            throw new ArgumentNullException(nameof(service), "Service not found");

        return services.Get(service);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return base.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        services?.Inject(instance);
    }

    protected override void OnExit(object sender, EventArgs e)
    {
        services?.Dispose();

        base.OnExit(sender, e);
    }
}
