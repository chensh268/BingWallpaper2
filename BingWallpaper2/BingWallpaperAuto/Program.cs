﻿using BingWallpaper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaperAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreEngine.Current.SetWallpaper();
        }
    }
}
