namespace Solution1.Module.Utils
{
    internal class AppSettings
    {
        public static string ConnectionString
        {
            get
            {
                return @"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\mssqllocaldb;Initial Catalog=Solution1g";
            }

        }
    }
}