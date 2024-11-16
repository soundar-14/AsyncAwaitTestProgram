namespace AsyncAwaitTestProgramWeb.Operations
{
    public class SecondOperation
    {
        public static string GetSecondOperation(string? s = null)
        {
            try
            {
                return ThirdOperation.GetThirdOperation(s);
            }
            catch (Exception ex)
            {
                //throw ex;
                throw;
            }
        }
    }
}
