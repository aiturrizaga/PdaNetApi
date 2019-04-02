using System;
using System.Devices;

namespace PortableDevices.ActiveSync
{
    class FileManagerController
    {
        public static bool checkDevice()
        {
            RemoteDeviceManager manager = new RemoteDeviceManager();
            RemoteDevice firstConnectedDevice = manager.Devices.FirstConnectedDevice;

            if (firstConnectedDevice == null)
            {
                Console.Error.WriteLine("No se encontro ningún dispositivo conectado");
                return false;
            }
            else
            {
                Console.WriteLine("Dispositivo conectado -> " + firstConnectedDevice.Name + ":" + firstConnectedDevice.Platform);
                return true;
            }
        }

        public static void sendFileToDevice(string path, string file, string newName)
        {
            using (RemoteDeviceManager r = new RemoteDeviceManager())
            {
                using (RemoteDevice device = r.Devices.FirstConnectedDevice)
                {
                    string myDocs = device.GetFolderPath(SpecialFolder.MyDocuments);
                    string deviceFile = myDocs + "\\" + newName;
                    string localFile = path + "\\" + file;

                    RemoteFile.CopyFileToDevice(device, localFile, deviceFile, true);

                }
            }
        }

        public static void getFileFromDevice(string path, string file)
        {
            using (RemoteDeviceManager r = new RemoteDeviceManager())
            {
                using (RemoteDevice device = r.Devices.FirstConnectedDevice)
                {
                    string myDocs = device.GetFolderPath(SpecialFolder.MyDocuments);
                    string deviceFile = myDocs + "\\" + file;
                    string localFile = path + "\\" + file;
                    if (RemoteFile.Exists(device, deviceFile))
                    {
                        RemoteFile.CopyFileFromDevice(device, deviceFile, localFile, true);
                    }
                    else
                    {
                        Console.Error.WriteLine("El archivo " + deviceFile + " no existe");
                    }
                }
            }
        }

        public static void deleteDeviceFile(string file)
        {
            using (RemoteDeviceManager r = new RemoteDeviceManager())
            {
                using (RemoteDevice device = r.Devices.FirstConnectedDevice)
                {
                    string myDocs = device.GetFolderPath(SpecialFolder.MyDocuments);
                    if (RemoteFile.Exists(device, myDocs + "\\" + file))
                    {
                        RemoteFile.Delete(device, myDocs + "\\" + file);
                    }
                    else
                    {
                        Console.Error.WriteLine("El archivo " + file + " no existe");
                    }
                }
            }
        }

        public static void searchDeviceFile(string file)
        {
            using (RemoteDeviceManager r = new RemoteDeviceManager())
            {
                using (RemoteDevice device = r.Devices.FirstConnectedDevice)
                {
                    string myDocs = device.GetFolderPath(SpecialFolder.MyDocuments);
                    if (RemoteFile.Exists(device, myDocs + "\\" + file))
                    {
                        Console.WriteLine("El archivo " + file + " fue encontrado");
                    }
                    else
                    {
                        Console.Error.WriteLine("El archivo " + file + " no existe");
                    }
                }
            }
        }

        public static void copyFile(string file, string newName)
        {
            using (RemoteDeviceManager r = new RemoteDeviceManager())
            {
                using (RemoteDevice device = r.Devices.FirstConnectedDevice)
                {
                    string myDocs = device.GetFolderPath(SpecialFolder.MyDocuments);
                    string newFile = myDocs + "\\" + newName;
                    string oldFile = myDocs + "\\" + file;

                    if (RemoteFile.Exists(device, myDocs + "\\" + file))
                    {
                        RemoteFile.Copy(device, oldFile, newFile, true);
                    }
                    else
                    {
                        Console.Error.WriteLine("El archivo " + file + " no existe");
                    }

                }
            }
        }
    }
}
