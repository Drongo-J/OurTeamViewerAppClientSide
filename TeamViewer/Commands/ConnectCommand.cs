using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TeamViewer.AdditionalClasses;
using TeamViewer.ViewModels;

namespace TeamViewer.Commands
{
    public class ConnectCommand : ICommand
    {
        public ConnectCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public MainViewModel MainViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        Network network = new Network();
        public void Execute(object parameter)
        {
            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);
            //dispatcherTimer.Tick += DispatcherTimer_Tick;
            //dispatcherTimer.Start();
            ScreenShot screenShot = new ScreenShot();
            var imagepath = screenShot.GetScreenShotPath(500000);
            ImageHelper imageHelper = new ImageHelper();
            var imagebytes = imageHelper.GetBytesOfImage(imagepath);
            network.DataBytes = imagebytes;
            Task.Run(() =>
            {
                network.StartTcpClient();
            });
            int i = 0;
            //Task.Run(() => {
            //    while (true)
            //    {
            //        ScreenShot screenShot = new ScreenShot();
            //        var imagepath = screenShot.GetScreenShotPath(++i);
            //        ImageHelper imageHelper = new ImageHelper();
            //        var imagebytes = imageHelper.GetBytesOfImage(imagepath);
            //        network.DataBytes = imagebytes;

            //    }
            //});
        }
        //private void DispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    Task.Run(() =>
        //    {
        //        ScreenShot screenShot = new ScreenShot();
        //        var imagepath = screenShot.GetScreenShotPath(1);
        //        ImageHelper imageHelper = new ImageHelper();
        //        var imagebytes = imageHelper.GetBytesOfImage(imagepath);
        //        network.DataBytes = imagebytes;
        //    });
        //}
    }
}
