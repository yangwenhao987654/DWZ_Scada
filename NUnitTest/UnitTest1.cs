using DWZ_Scada.ProcessControl.DTO.OP60;
using System.Diagnostics;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            //Assert.Fail();
            try
            {
                AtlBrxTestDto dto = AtlBrxTestDto.ParseDto(AtlBrxTestDto.TestInput);
            }
            catch (Exception ex)
            {        
                Assert.Fail(ex.Message);
                throw ex;
            }
        }


        [Test]
        public void Test3()
        {
            //Assert.Fail();
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    SafetyTestDto dto = SafetyTestDto.ParseDto(SafetyTestDto.OKStr);
                }               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                throw ex;
            }
            sw.Stop();
            Assert.Pass($"测试成功 运行耗时:{sw.ElapsedMilliseconds} ms");
        }
    }
}