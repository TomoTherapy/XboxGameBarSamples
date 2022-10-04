using Microsoft.Gaming.XboxGameBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page, INotifyPropertyChanged
    {
        private bool flag = false;
        private XboxGameBarWidget widget;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Text { get => ((App)Application.Current).Text; set { ((App)Application.Current).Text = value; OnPropertyChanged(); } }

        public BlankPage1()
        {
            this.InitializeComponent();

            DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            widget = e.Parameter as XboxGameBarWidget;

            widget.SettingsClicked += Widget_SettingsClicked;

            await widget.CenterWindowAsync();
        }

        private async void Widget_SettingsClicked(XboxGameBarWidget sender, object args)
        {
            await sender.ActivateSettingsAsync();

            await sender.CenterWindowAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
                Text = "Jesus Fuck";
            else
                Text = "Allah Fuck";

            flag = !flag;

            //await (sender as XboxGameBarWidget).CenterWindowAsync();
        }
    }
}
