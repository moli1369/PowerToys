// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.PowerToys.Settings.UI.OOBE.Enums;
using Microsoft.PowerToys.Settings.UI.OOBE.ViewModel;
using Microsoft.PowerToys.Settings.UI.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Microsoft.PowerToys.Settings.UI.OOBE.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OobeAwake : Page
    {
        public OobePowerToysModule ViewModel { get; set; }

        public OobeAwake()
        {
            InitializeComponent();
            ViewModel = new OobePowerToysModule(OobeShellPage.OobeShellHandler.Modules[(int)PowerToysModulesEnum.Awake]);
            DataContext = ViewModel;
        }

        private void SettingsLaunchButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (OobeShellPage.OpenMainWindowCallback != null)
            {
                OobeShellPage.OpenMainWindowCallback(typeof(AwakePage));
            }

            ViewModel.LogOpeningSettingsEvent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LogOpeningModuleEvent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.LogClosingModuleEvent();
        }
    }
}
