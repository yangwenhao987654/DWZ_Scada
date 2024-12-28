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
            //CoilsSpeed = dto.CoilsSpeed;
            CoilsTimes = dto.CoilsTimes;
            BreachNo = dto.BreachNo;
            //TensionValueList = new();
        }

        public CoildDataDto()
        {

        }

        public bool Good { get; set; }


        /// <summary>
        /// 当前批次号
        /// </summary>
        public string BreachNo { get; set; }

        /// <summary>
        /// 当前绕线圈数
        /// </summary>
        public   double CoilsCurNum { get; set; }

        /// <summary>
        /// 绕线目标圈数
        /// </summary>
        public   double CoilsTargetNum { get; set; }

      /*  /// <summary>
        /// 绕线速度
        /// </summary>
        public   double CoilsSpeed { get; set; }*/

        /// <summary>
        /// 绕线周期
        /// </summary>
        public double CoilsTimes { get; set; }

        /// <summary>
        /// 张力值 List
        /// </summary>
        public string TensionValue { get; set; }
    }
}
