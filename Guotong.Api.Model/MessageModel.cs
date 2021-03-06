﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 500;

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "服务器异常";

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }
    }
}
