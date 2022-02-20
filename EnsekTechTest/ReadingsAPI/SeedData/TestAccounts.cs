using System.Reflection;

namespace ReadingsAPI.SeedData
{
    public class TestAccounts
    {
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var file = "ReadingsAPI.SeedData.Test_Accounts.csv";

                using (Stream? stream = assembly.GetManifestResourceStream(file))
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    while (reader.Peek() != -1)
                    {
                        var row = reader.ReadLine();
                        var details = row.Split(',');
                        if (details.Length > 0)
                        {
                            accounts.Add(new Account() { AccountId = Convert.ToInt32(details[0].ToString()), FirstName = details[1].ToString(), LastName = details[2].ToString() });
                        }
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return accounts;
        }
    }
}
