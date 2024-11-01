using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO.OP20
{
    public class CoildDataDto
    {
  
        public CoildDataDto(CoildDataDto dto)
        {

            CoilsCurNum = dto.CoilsCurNum;
            CoilsTargetNum = dto.CoilsTargetNum;
            CoilsSpeed = dto.CoilsSpeed;
            CoilsTimes = dto.CoilsTimes;
            TensionValue = 0;
        }

        public CoildDataDto()
        {
        }

        /// <summary>
        /// 当前绕线圈数
        /// </summary>
        public   uint CoilsCurNum { get; set; }

        /// <summary>
        /// 绕线目标圈数
        /// </summary>
        public   uint CoilsTargetNum { get; set; }

        /// <summary>
        /// 绕线速度
        /// </summary>
        public   uint CoilsSpeed { get; set; }

        /// <summary>
        /// 绕线周期
        /// </summary>
        public uint CoilsTimes { get; set; }

        /// <summary>
        /// 张力值
        /// </summary>
        public short TensionValue { get; set; }

       
    }
}
