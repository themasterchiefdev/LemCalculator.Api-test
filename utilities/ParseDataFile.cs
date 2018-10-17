using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LemCalculator.utilities
{
    public class ParseDataFile
    {
        public IList<BankDetails> LoadJson()
        {
            IList<BankDetails> items = new List<BankDetails>();
            try
            {
                using (var reader = new StreamReader("./utilities/lemdata.json"))
                {
                    var json = reader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<BankDetails>>(json);
                }

                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return items;
        }
    }
}