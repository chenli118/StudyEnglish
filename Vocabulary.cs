using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEnglish
{
    internal class Vocabulary
    {
        public Vocabulary() { }
        /// <summary>
        /// 排序号
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 单词
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// 中文释义
        /// </summary>
        public string WordContent { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Leve { get; set; }
        /// <summary>
        /// 热度
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 重复度
        /// </summary>
        public string Repetition { get; set; }
        /// <summary>
        /// 最后完成时间
        /// </summary>
        public string LastTimestamp { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }


    }
}
