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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Dispositivo no encontrado!");
                    status = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dispositivo encontrado: " + currentDevice.FriendlyName);
                    Console.WriteLine("Dispositivo con Android");
                    Console.ResetColor();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
                status = false;
            }
            return status;
        }

        public static void sendFileToDevice(String deviceFolder, String localPath, String localFile, String newNameFile)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (FileManagerModel.searchDeviceFile(currentDevice, deviceFolder, localFile))
                {
                    FileManagerModel.deleteDeviceFile(currentDevice, deviceFolder, localFile);
                    FileManagerModel.sendFileToDevice(currentDevice, deviceFolder, localPath, localFile, newNameFile);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El archivo " + localFile + " fue movido al dispositivo");
                    Console.ResetColor();
                    currentDevice.Disconnect();
                }
                else
                {
                    FileManagerModel.sendFileToDevice(currentDevice, deviceFolder, localPath, localFile, newNameFile);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El archivo " + localFile + " fue movido al dispositivo");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public static void getFileFromDevice(String deviceFolder, String localPath, String file)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (FileManagerModel.searchDeviceFile(currentDevice, deviceFolder, file))
                {
                    FileManagerModel.getFileFromDevice(currentDevice, deviceFolder, localPath, file);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El archivo " + file + " fue movido a la PC");
                    Console.ResetColor();
                    currentDevice.Disconnect();
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Error al mover el archivo a la PC");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public static void deleteDeviceFile(String deviceFolder, String file)
        {
            try
            {
                PortableDevice currentDevice = FileManagerModel.getCurrentDevice();
                if (FileManagerModel.searchDeviceFile(currentDevice, deviceFolder, file))
                {
                    FileManagerModel.deleteDeviceFile(currentDevice, deviceFolder, file);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Error.WriteLine("El archivo " + file + " fue eliminado");
                    Console.ResetColor();
                    currentDevice.Disconnect();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Error al eliminar el archivo");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El archivo " + file + " fue encontrado");
                    Console.ResetColor();
                    status = true;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(file + " no encontrado!");
                    Console.ResetColor();
                    status = false;
                }
                currentDevice.Disconnect();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
                status = false;
            }
            return status;
        }
    }
}
