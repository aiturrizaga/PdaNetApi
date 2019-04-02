using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortableDevices.MtpDevice
{
    class FileManagerController
    {
        public static bool checkDevice()
        {
            bool status = false;
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (null == currentDevice)
                {
                    Console.Error.WriteLine("Dispositivo no encontrado!");
                    status = false;
                }
                else
                {
                    Console.WriteLine("Dispositivo encontrado: " + currentDevice.FriendlyName);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return status;
        }

        public static void sendFileToDevice(String deviceFolder, String localPath, String localFile)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                FileManagerModel.sendFileToDevice(currentDevice, deviceFolder, localPath, localFile);
                currentDevice.Disconnect();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static void getFileFromDevice(String deviceFolder, String localPath, String file)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (searchDeviceFile(deviceFolder, file))
                {
                    FileManagerModel.getFileFromDevice(currentDevice, deviceFolder, localPath, file);
                    Console.Error.WriteLine("El archivo " + file + " fue movido a la PC");
                    currentDevice.Disconnect();
                } else
                {
                    Console.Error.WriteLine("Error al mover el archivo a la PC");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static void deleteDeviceFile(String deviceFolder, String file)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (searchDeviceFile(deviceFolder, file))
                {
                    FileManagerModel.deleteDeviceFile(currentDevice, deviceFolder, file);
                    Console.Error.WriteLine("El archivo " + file + " fue eliminado");
                    currentDevice.Disconnect();
                }
                else
                {
                    Console.Error.WriteLine("Error al eliminar el archivo");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static bool searchDeviceFile(String deviceFolder, String file)
        {
            bool status = false;
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if(FileManagerModel.searchDeviceFile(currentDevice, deviceFolder, file))
                {
                    status = true;
                } else
                {
                    status = false;
                }
                currentDevice.Disconnect();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }
    }
}
