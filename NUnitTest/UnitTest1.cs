using DWZ_Scada.ProcessControl.DTO.OP60;

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
            try
            {
                SafetyTestDto dto = SafetyTestDto.ParseDto(SafetyTestDto.OKStr);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                throw ex;
            }
        }
    }
}