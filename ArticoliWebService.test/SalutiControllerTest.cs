namespace ArticoliWebService.test
{
    public class SalutiControllerTest
    {
        SalutiController salutiController;

        public SalutiControllerTest()
        {
            salutiController = new SalutiController();
        }

        [Fact]
        public testGetSaluti()
        {
            string retVal = salutiController.getSaluti();
            Assert.Equal("stringa del metodo", retVal);
        }

    }
}