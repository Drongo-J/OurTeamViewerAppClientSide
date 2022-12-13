using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TeamViewer.AdditionalClasses
{
    public class Network
    {
        public byte[] DataBytes { get; set; }
        public void StartTcpClient()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(NetworkProtocol.IPAddress), NetworkProtocol.TcpPort);
                TcpClient client = new TcpClient();
                Console.WriteLine("Starting to connect server");
                while (!client.Connected)
                {
                    try
                    {

                        client.Connect(endPoint);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                //MessageBox.Show("I am Client and I connected");
                int i = 3;
                while (true)
                {
                    Task.Delay(50);
                    ScreenShot screenShot = new ScreenShot();
                    var imagepath = screenShot.GetScreenShotPath(++i);
                    ImageHelper imageHelper = new ImageHelper();
                    var imagebytes = imageHelper.GetBytesOfImage(imagepath);
                    DataBytes = imagebytes;
                    NetworkStream stream = client.GetStream();
                    stream.Write(DataBytes, 0, DataBytes.Length);
                    //MessageBox.Show("I sent");
                    //Thread.Sleep(100);
                }
                client.Close();

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
