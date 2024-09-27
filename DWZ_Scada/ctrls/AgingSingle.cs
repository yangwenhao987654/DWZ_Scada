using System;

namespace DWZ_Scada.ctrls
{
    [Serializable]
    public class AgingSingle
    {
        public int Index { get; set; }
        public bool IsEnable { get; set; }
        public int TbxPPIDIndex { get; set; }
        public int ButtonIndex { get; set; }
        public int LblPassIndex { get; set; }
        public int LblFailIndex { get; set; }
        public int LblMaxIndex { get; set; }
        public int LblMinIndex { get; set; }
        public int LblResult { get; set; }
        public AgingSingle(int index)
        {
            Index = index;
            IsEnable = false;
        }

        public string SetPPID(string ppid)
        {
            var errMsg = "";
            /*var handle = IntPtr.Zero;
            (errMsg, handle) = AutoTest.GetChildHandle(TbxPPIDIndex);
            if (errMsg != "")
            {
                return errMsg;
            }
            errMsg = AutoTest.SendMessageInput(handle, ppid);*/
            return errMsg;
        }
        public string ClickBtn()
        {
            var errMsg = "";
            var handle = IntPtr.Zero;
            /*(errMsg, handle) = AutoTest.GetChildHandle(ButtonIndex);
            if (errMsg != "")
            {
                return errMsg;
            }
            errMsg = AutoTest.SendMessageBtn(handle);*/
            return errMsg;
        }

        public (object errmsg, object state) GetLbl()
        {
            throw new NotImplementedException();
        }
    }
}
