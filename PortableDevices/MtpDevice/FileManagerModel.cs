using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortableDevices.MtpDevice
{
    class FileManagerModel
    {
        // public static string _EN = "Internal shared storage";
        // public static string _ES = "Almacenamiento interno compartido";

        public static PortableDevice getCurrentDevice()
        {
            PortableDevice currentDevice = null;
            try
            {
                var devices = new PortableDeviceCollection();
                if (null == devices)
                {
                    Console.Error.WriteLine("Dispositivo no encontrado!");
                }
                else
                {
                    devices.Refresh();
                    currentDevice = devices.First();
                    if (null == currentDevice)
                    {
                        Console.Error.WriteLine("Dispositivo no encontrado!");
                    }
                    else
                    {
                        Console.WriteLine("Dispositivo encontrado: " + currentDevice.FriendlyName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return currentDevice;
        }

        public static void sendFileToDevice(PortableDevice device, String deviceFolder, String localPath, String localFile)
        {
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                if (null == result)
                {
                    Console.Error.WriteLine(phoneDir + " no encontrado!");
                }
                else
                {
                    device.TransferContentToDevice(result, localPath + localFile);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static void getFileFromDevice(PortableDevice device, String deviceFolder, String localPath, String file)
        {
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                if (null == result)
                {
                    Console.Error.WriteLine(phoneDir + " no encontrado!");
                }
                else
                {
                    PortableDeviceFile deviceFile = ((PortableDeviceFolder)result).FindFile(file);
                    device.TransferContentFromDevice(deviceFile, localPath, file);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static void deleteDeviceFile(PortableDevice device, String deviceFolder, String file)
        {
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                PortableDeviceFile deviceFile = result.FindFile(file);
                if (null == result)
                {
                    Console.Error.WriteLine(phoneDir + " no encontrado!");
                }
                else
                {
                    device.DeleteFile(deviceFile);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public static bool searchDeviceFile(PortableDevice device, String deviceFolder, String file)
        {
            bool status = false;
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                PortableDeviceFile deviceFile = ((PortableDeviceFolder)result).FindFile(file);
                if (null == result)
                {
                    Console.Error.WriteLine(phoneDir + " no encontrado!");
                }
                else
                {
                    if (null == deviceFile)
                    {
                        Console.Error.WriteLine(file + " no encontrado!");
                        status = false;
                    } else
                    {
                        Console.WriteLine("El archivo " + file + " fue encontrado");
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return status;
        }
    }
}
