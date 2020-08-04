using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Attributes
{
    public class CachingAttribute
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        public int AbsoluteExpiration { get; set; }

        /// <summary>
        /// 自定义Key
        /// </summary>
        public string CustomKeyValue { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; } = false;
    }
}
