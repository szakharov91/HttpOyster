using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HttpOyster.UI;

public class Bootstrapper: BootstrapperBase
{
    public Bootstrapper()
    {
        Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.Empty, default(PropertyChangedCallback), null));
    }

    protected override void Configure()
    {
        base.Configure();
    }

    protected override object GetInstance(Type service, string key)
    {
        return base.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return base.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        base.BuildUp(instance);
    }

    protected override void OnExit(object sender, EventArgs e)
    {
        base.OnExit(sender, e);
    }
}
