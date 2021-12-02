using GalaSoft.MvvmLight;
using ListViewData.Common;
using System;
using System.Windows;


namespace ListViewData.ViewModel
{

    public class MainViewModel : NotifyBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public CommandBase MaxCommanbase { get; set; } = new CommandBase();
        public CommandBase LeftPanteBtn { get; set; } = new CommandBase();
   
        public MainViewModel()
        {
            this.LeftPanteBtn.DoExecute = new Action<object>((o) =>
            {
                GetHardDiskFreeSpace(GbSpace);
                Console.WriteLine(GbSpace);
            });

        
            this.LeftPanteBtn.DoCanExecute = new Func<object, bool>((o) =>
            {
                return true;
            });
        }


        private string _gbSpace;

        public string GbSpace
        {
            get { return _gbSpace; }
            set
            {
                _gbSpace = value;
                this.Notify();
            }
        }
        /// <summary>
        /// 获取指定驱动器剩余空间
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long freeSpace = new long();
            str_HardDiskName = str_HardDiskName + "D:\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)

                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return freeSpace;
        }
        /// <summary>
        /// 获取指定驱动器总大小
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + "D:\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }
    }
}