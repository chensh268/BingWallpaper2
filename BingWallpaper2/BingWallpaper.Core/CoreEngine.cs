﻿using BingWallpaper.Core.Model;
using BingWallpaper.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaper.Core
{
    /// <summary>
    /// 核心引擎
    /// </summary>
    public class CoreEngine
    {
        #region 单例模式
        private static object _lockObj = new object();
        private static CoreEngine _current;
        /// <summary>
        /// 单例模式
        /// </summary>
        public static CoreEngine Current 
        { 
            get
            {
                lock (_lockObj)
                {
                    if (_current == null)
                    {
                        _current = new CoreEngine();
                    }
                    return _current;
                }
            } 
        }

        #endregion

        public ObservableCollection<ImageSizeModel> ImageSizeList { get; set; } = new ObservableCollection<ImageSizeModel>();
        public ObservableCollection<WallpaperStyleModel> WallpaperStyleList { get; set; } = new ObservableCollection<WallpaperStyleModel>();

        public AppSettingOperation AppSetting { get; private set; } = new AppSettingOperation();
        private CoreEngine()
        {
            ImageSizeList.Add(new ImageSizeModel("1920*1200", ImageSizeType._1200p));
            ImageSizeList.Add(new ImageSizeModel("1920*1080", ImageSizeType._1080p));
            ImageSizeList.Add(new ImageSizeModel("1366*768", ImageSizeType._720p));

            WallpaperStyleList.Add(new WallpaperStyleModel("填充", WallpaperModeType.Full));
            WallpaperStyleList.Add(new WallpaperStyleModel("适应", WallpaperModeType.Adapt));
            WallpaperStyleList.Add(new WallpaperStyleModel("拉伸", WallpaperModeType.Stretch));
            WallpaperStyleList.Add(new WallpaperStyleModel("平铺", WallpaperModeType.Tiling));
            WallpaperStyleList.Add(new WallpaperStyleModel("居中", WallpaperModeType.Center));
            WallpaperStyleList.Add(new WallpaperStyleModel("跨区", WallpaperModeType.Span));

        }
    }
}