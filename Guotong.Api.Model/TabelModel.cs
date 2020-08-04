using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model
{
    public class TabelModel<T>
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 返回数据集
        /// </summary>
        public List<T> Data { get; set; }
    }
}
