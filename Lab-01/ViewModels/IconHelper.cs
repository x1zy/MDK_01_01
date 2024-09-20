﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_01.ViewModels
{
    public static class IconHelper
    {
        #region DLLs

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(nint hObjetc);

        [DllImport("shell32")]
        private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);

        #endregion

        #region Flags

        private const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        private const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        private const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        private const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        private const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        private const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        private const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        private const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        private const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        private const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        private const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

        private const uint SHGFI_ICON = 0x000000100;     // получить иконку
        private const uint SHGFI_DISPLAYNAME = 0x000000200;     // получить имя дисплея
        private const uint SHGFI_TYPENAME = 0x000000400;      // получить имя типа
        private const uint SHGFI_ATTRIBUTES = 0x000000800;      // получить атрибуты
        private const uint SHGFI_ICONLOCATION = 0x000001000;     // получить расположение иконки
        private const uint SHGFI_EXETYPE = 0x000002000;     // вернуть тип exe 
        private const uint SHGFI_SYSICONINDEX = 0x000004000;     // получить индекс системной иконки
        private const uint SHGFI_LINKOVERLAY = 0x000008000;     // наложить ссылку на иконку
        private const uint SHGFI_SELECTED = 0x000010000;     // показать иконку в выбранном состоянии
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // получить только указанные атрибуты
        private const uint SHGFI_LARGEICON = 0x000000000;      // получить большую иконку
        private const uint SHGFI_SMALLICON = 0x000000001;     // получить маленькую иконку
        private const uint SHGFI_OPENICON = 0x000000002;     // получить значок открытия
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;      // получить значок размера оболочки
        private const uint SHGFI_PIDL = 0x000000008;     // строка, указывающая путь в DOS-Format.
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // указывает атрибуты найденного файла

        #endregion

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public nint hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #endregion

        public static ImageSource ToImageSource(this Icon ico)
        {
            Bitmap bitmap = ico.ToBitmap();
            nint hBitmap = bitmap.GetHbitmap();

            ImageSource image =
                Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    nint.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

            if (!DeleteObject(hBitmap))
            {
                MessageBox.Show("Не удалось удалить неиспользуемый объект растрового изображения");
            }

            return image;
        }

        public static Icon GetIconOfFile(string path, bool smallIcon, bool isDirectoryOrDrive)
        {
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            if (smallIcon)
                flags |= SHGFI_SMALLICON;

            uint attributes = FILE_ATTRIBUTE_NORMAL;
            if (isDirectoryOrDrive)
                attributes |= FILE_ATTRIBUTE_DIRECTORY;

            int success =
                SHGetFileInfo(
                    path,
                    attributes,
                    out SHFILEINFO shfi,
                    (uint)Marshal.SizeOf(typeof(SHFILEINFO)),
                    flags);

            if (success == 0)
                return null;

            return Icon.FromHandle(shfi.hIcon);
        }
    }
}
