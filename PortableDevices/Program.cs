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
                checkCurrentDeviceOS(args[1]);
            }
            else
            {
                if (ActiveSync.FileManagerController.checkDevice(false))
                {
                    executeApiForActiveSync(args);
                } else
                {
                    executeApiForMtpDevice(args);
                }
            }

            Console.ReadKey();
        }

        public static void checkCurrentDeviceOS(string OS)
        {
            if (OS.Equals("W"))
            {
                ActiveSync.FileManagerController.checkDevice(true);
            }
            else if (OS.Equals("A"))
            {
                MtpDevice.FileManagerController.checkDevice();
            }
        }

        public static void executeApiForMtpDevice(string[] args)
        {
            string deviceFolder = MtpDevice.FileManagerModel.STORAGE_EN + @"\DCIM";

            switch (args[0])
            {
                case "enviar":
                    Console.WriteLine("Enviando archivo al dispositivo ...");
                    MtpDevice.FileManagerController.sendFileToDevice(deviceFolder, args[1], args[2], args[3]);
                    break;
                case "traer":
                    Console.WriteLine("Enviando archivo a la PC ...");
                    MtpDevice.FileManagerController.getFileFromDevice(deviceFolder, args[1], args[2]);
                    break;
                case "borrar":
                    Console.WriteLine("Borrando archivo del dispositivo ...");
                    MtpDevice.FileManagerController.deleteDeviceFile(deviceFolder, args[1]);
                    break;
                case "buscar":
                    Console.WriteLine("Buscando archivo del dispositivo ...");
                    MtpDevice.FileManagerController.searchDeviceFile(deviceFolder, args[1]);
                    break;
                case "copiar":
                    Console.WriteLine("Copiando archivo ...");
                    Console.WriteLine("El método para copiar archivo no esta disponible en el API para Android");
                    Console.WriteLine("Nombre del archivo: " + args[1] + " Nombre de la copia: " + args[2]);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Proceso finalizado");

        }

        public static void executeApiForActiveSync(string[] args)
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
