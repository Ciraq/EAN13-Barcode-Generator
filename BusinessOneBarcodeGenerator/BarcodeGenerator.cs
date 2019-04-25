using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOneBarcodeGenerator
{
    public static class BarcodeGenerator
    {
        public static long GenerateEAN13(long code)
        {
            long barcode = 0;
            try
            {
                if (code.ToString().Length == 12)
                {
                    var str = code.ToString();

                    //convert string to int array
                    var numbers = str.Select(c => c - '0').ToArray();
                    int result1 = 0;
                    int result2 = 0;

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            result1 += numbers[i];
                        }
                        else
                        {
                            result2 += numbers[i];
                        }
                    }

                    int sum = (result1 * 3) + result2;
                    //int sum2 = sum + result2;

                    int RoundSum = (10 - sum % 10) + sum;
                    int totalsum = RoundSum - sum;

                    barcode = Convert.ToInt64(code + totalsum.ToString());
                    return barcode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return barcode;
        }
    }
}
