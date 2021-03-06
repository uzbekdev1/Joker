﻿using System.Windows;
using CommonServiceLocator;
using Joker.WPF.Sample.Modularity;
using Joker.WPF.Sample.ViewModels;
using Ninject;
using Prism.Ioc;
using Prism.Ninject.Ioc;

namespace Joker.WPF.Sample
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    private readonly IKernel kernel = new StandardKernel();

    #region CreateContainerExtension

    protected override IContainerExtension CreateContainerExtension()
    {
      return new NinjectContainerExtension(kernel);
    }

    #endregion

    #region RegisterTypes

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      kernel.Bind<ShellViewModel>().ToSelf().InSingletonScope();

      kernel.Load<AppNinjectModule>();
    }

    #endregion

    #region CreateShell

    protected override Window CreateShell()
    {
      return new Shell();
    }

    #endregion

    #region InitializeShell

    protected override void InitializeShell(Window shell)
    {
      base.InitializeShell(shell);
       
      if (shell is FrameworkElement shellFrameworkElement)
        shellFrameworkElement.DataContext = kernel.Get<ShellViewModel>();
    }

    #endregion

    #region ConfigureServiceLocator

    protected override void ConfigureServiceLocator()
    {
      kernel.Bind<IServiceLocator>().To<NinjectServiceLocator>().InSingletonScope();

      base.ConfigureServiceLocator();
    }

    #endregion

    #region OnExit

    protected override void OnExit(ExitEventArgs e)
    {
      base.OnExit(e);

      kernel.Dispose();
    }

    #endregion
  }
}