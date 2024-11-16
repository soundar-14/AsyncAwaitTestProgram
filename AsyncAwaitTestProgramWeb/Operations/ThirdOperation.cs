namespace AsyncAwaitTestProgramWeb.Operations
{
    public class ThirdOperation
    {
        public static string GetThirdOperation(string? s = null)
        {
            try
            {
                return (1 / int.Parse(s)).ToString();
            }
            catch (Exception ex)
            {
                //throw ex;
                throw;
            }
        }
    }
}
