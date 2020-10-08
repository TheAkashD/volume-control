using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi.CoreAudio;
using System.IO.Ports;

namespace VolumeControlArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort sp = new SerialPort();
            sp.BaudRate = 9600;
            sp.PortName = "COM6";

            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            Console.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);

            try
            {
                sp.Open();
            }
            catch
            {
                //sp.Close();
                Console.WriteLine("Please plug in your Volume Control Module.");
            }

            while (true)
            {
                if (sp.IsOpen)
                {
                    var val = sp.ReadLine();
                    defaultPlaybackDevice.Volume = Convert.ToDouble(val);
                    Console.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
                }
                else
                {
                    Console.WriteLine("Please plug in your Volume Control Module.");
                }
            }
        }
    }
} 