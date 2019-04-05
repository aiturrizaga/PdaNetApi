using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PortableDevices.MtpDevice
{
    class FileManagerModel
    {
        public static string STORAGE_EN = "Internal shared storage";
        // public static string STORAGE_ES = "Almacenamiento interno compartido";

        public static PortableDevice getCurrentDevice()
        {
            PortableDevice currentDevice = null;
            try
            {
                var devices = new PortableDeviceCollection();
                //if (null == devices)
                //{
                    
                //}
                //else
                //{
                    devices.Refresh();
                    currentDevice = devices.First();
                    /*if (null == currentDevice)
                    {
                        Console.Error.WriteLine("Dispositivo no encontrado!");
                    }
                    else
                    {
                        Console.WriteLine("Dispositivo encontrado: " + currentDevice.FriendlyName);
                    }*/
                //}
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return currentDevice;
        }

        public static bool sendFileToDevice(PortableDevice device, String deviceFolder, String localPath, String localFile, String newNameFile)
        {
            bool status = false;
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                if (null == result)
                {
                    status = false;
                }
                else
                {
                    device.TransferContentToDevice(result, localPath + localFile);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public static bool getFileFromDevice(PortableDevice device, String deviceFolder, String localPath, String file)
        {
            bool status = false;
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                if (null == result)
                {
                    //Console.Error.WriteLine(phoneDir + " no encontrado!");
                    status = false;
                }
                else
                {
                    PortableDeviceFile deviceFile = ((PortableDeviceFolder)result).FindFile(file);
                    device.TransferContentFromDevice(deviceFile, localPath, file);
                    status = true;
                }
            }
            catch (Exception)
            {
                //Console.Error.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public static bool deleteDeviceFile(PortableDevice device, String deviceFolder, String file)
        {
            bool status = false;
            try
            {
                String phoneDir = deviceFolder;
                PortableDeviceFolder root = device.Root();
                PortableDeviceFolder result = root.FindDir(phoneDir);
                PortableDeviceFile deviceFile = result.FindFile(file);
                if (null == result)
                {
                    //Console.Error.WriteLine(phoneDir + " no encontrado!");
                    status = false;
                }
                else
                {
                    device.DeleteFile(deviceFile);
                    status = true;
                }
            }
            catch (Exception)
            {
                //Console.Error.WriteLine(ex.Message);
                status = false;
            }
            return status;
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
                    status = false;
                    //Console.Error.WriteLine(phoneDir + " no encontrado!");
                }
                else
                {
                    if (null == deviceFile)
                    {
                        //Console.Error.WriteLine(file + " no encontrado!");
                        status = false;
                    } else
                    {
                        //Console.WriteLine("El archivo " + file + " fue encontrado");
                        status = true;
                    }
                }
            }
            catch (Exception)
            {
                //Console.Error.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }
    }
}
