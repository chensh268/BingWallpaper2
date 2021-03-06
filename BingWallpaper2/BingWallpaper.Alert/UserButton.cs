﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BingWallpaper.Popup
{
    /// <summary>
    /// 用户按钮
    /// </summary>
    public class UserButton
    {
        private Action _onBtnClickCallback;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="action">按钮回调方法</param>
        public UserButton(Action action)
        {
            _onBtnClickCallback = action;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="content">按钮文本</param>
        /// <param name="action">按钮回调方法</param>
        public UserButton(string content,Action action)
        {
            ButtonContent = content;
            _onBtnClickCallback = action;
        }

        #region 成员属性
        /// <summary>
        /// 按钮显示内容
        /// </summary>
        public string ButtonContent { get; set; } = "";

        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BackgroundColor { get; set; } = Color.Transparent;

        /// <summary>
        /// 文本颜色
        /// </summary>
        public Color FontColor { get; set; } = Color.Blue;

        /// <summary>
        /// 文本大小
        /// </summary>
        public int FontSize { get; set; } = 14;

        /// <summary>
        /// 边框粗细，默认1
        /// </summary>
        public int BorderThickness { get; set; } = 1;

        /// <summary>
        /// 边框颜色，默认透明
        /// </summary>
        public Color BorderColor { get; set; } = Color.Transparent;

        /// <summary>
        /// 高度，默认40
        /// </summary>
        public int Height { get; set; } = 30;

        /// <summary>
        /// 宽度，默认自动
        /// </summary>
        public int Width { get; set; } = -1;

        /// <summary>
        /// 点击按钮关闭弹框
        /// </summary>
        public bool CloseAlertIfClick { get; set; } = true;

        #endregion

        #region 成员方法

        /// <summary>
        /// 生成按钮控件
        /// </summary>
        /// <returns></returns>
        public Button GenerateControl()
        {
            var btn = new Button();
            btn.Content = ButtonContent;
            btn.Background = AlertTheme.GetBrush(BackgroundColor);
            btn.Padding = new System.Windows.Thickness(10, 5, 10, 5);
            btn.Margin = new System.Windows.Thickness(10, 0, 0, 0);
            btn.Height = Height;
            if (Width != -1)
                btn.Width = Width;
            btn.FontSize = FontSize;
            btn.Foreground =  AlertTheme.GetBrush(FontColor);
            btn.BorderBrush = AlertTheme.GetBrush(BorderColor);
            btn.BorderThickness = new System.Windows.Thickness(BorderThickness);
            btn.Margin = new System.Windows.Thickness(10, 0, 0, 0);
            if (-1!= Width) btn.Width = Width;
            btn.Cursor = System.Windows.Input.Cursors.Hand;
            btn.Click += (sender, e) =>
            {
                _onBtnClickCallback?.Invoke();
            };
            return btn;
        }

        /// <summary>
        /// 应用指定弹窗主题
        /// </summary>
        /// <param name="theme"></param>
        public void LoadAlertTheme(AlertTheme theme)
        {
            BorderColor=FontColor = theme.PullBackColor;

        }
        #endregion
    }
}
