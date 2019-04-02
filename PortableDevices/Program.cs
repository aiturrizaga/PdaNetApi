using System;
using System.Devices;
using System.Linq;

namespace PortableDevices
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Equals("verificar"))
            {
                MtpDevice.FileManagerController.checkDevice();
            }
            else
            {
                executeApi(args);
            }

            Console.ReadKey();
        }

        public static void executeApi(string[] args)
        {

            switch (args[0])
            {
                case "enviar":
                    Console.WriteLine("Enviando archivo al dispositivo ...");
                    MtpDevice.FileManagerController.sendFileToDevice(args[1], args[2], args[3]);
                    break;
                case "traer":
                    Console.WriteLine("Enviando archivo a la PC ...");
                    MtpDevice.FileManagerController.getFileFromDevice(args[1], args[2], args[3]);
                    break;
                case "borrar":
                    Console.WriteLine("Borrando archivo del dispositivo ...");
                    MtpDevice.FileManagerController.deleteDeviceFile(args[1], args[2]);
                    break;
                case "buscar":
                    Console.WriteLine("Buscando archivo del dispositivo ...");
                    MtpDevice.FileManagerController.searchDeviceFile(args[1], args[2]);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Proceso finalizado");

        }

        static void Main2(string[] args)
        {
            RemoteDeviceManager manager = new RemoteDeviceManager();
            RemoteDevice firstConnectedDevice = manager.Devices.FirstConnectedDevice;
            if (args[0].Equals("verificar"))
            {
                ActiveSync.FileManagerController.checkDevice();
            }
            else
            {
                executeApi(args);
            }

            //Console.ReadKey();
        }

        public static void executeApi2(string[] args)
        {
            RemoteDeviceManager manager = new RemoteDeviceManager();
            RemoteDevice firstConnectedDevice = manager.Devices.FirstConnectedDevice;

            switch (args[0])
            {
                case "enviar":
                    Console.WriteLine("Enviando archivo al dispositivo ...");
                    ActiveSync.FileManagerController.sendFileToDevice(args[1], args[2], args[3]);
                    break;
                case "traer":
                    Console.WriteLine("Enviando archivo a la PC ...");
                    ActiveSync.FileManagerController.getFileFromDevice(args[1], args[2]);
                    break;
                case "borrar":
                    Console.WriteLine("Borrando archivo del dispositivo ...");
                    ActiveSync.FileManagerController.deleteDeviceFile(args[1]);
                    break;
                case "buscar":
                    Console.WriteLine("Buscando archivo del dispositivo ...");
                    ActiveSync.FileManagerController.searchDeviceFile(args[1]);
                    break;
                case "copiar":
                    Console.WriteLine("Copiando archivo ...");
                    ActiveSync.FileManagerController.copyFile(args[1], args[2]);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Proceso finalizado");

        }

    }


}
