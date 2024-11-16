namespace AsyncAwaitTestProgramWeb.Operations
{
    public class FirstOperation
    {
        public static string GetFirstOperation(string? s = null)
        {
            try
            {
                return SecondOperation.GetSecondOperation(s);
            }
            catch(Exception ex)
            {
                //throw ex;
                throw;
            }
        }
    }
}
