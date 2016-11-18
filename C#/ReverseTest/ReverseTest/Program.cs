using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseTest
{
	class Program
	{
		// Reverses order of the bits in each byte in the array 
		private static void Reverse(byte[] values)
		{
            int i = 0;
            foreach(byte originalByte in values)
            {                
                values[i] = ReverseByte(originalByte);
                i++;
            }
        }
       
        public static byte ReverseByte(byte originalByte)
        {
            int result = 0;
            for (int i = 0; i < 8; i++)
            {
                result = result << 1;
                result += originalByte & 1;
                originalByte = (byte)(originalByte >> 1);
            }
            return (byte)result;
        }

        static void Main(string[] args)
		{
            byte[] data = { 0x0E, 0xDC, 0x01, 0x1B, 0x80 };

            foreach (byte originalByte in data)
            {
              Console.Write(  Convert.ToString(originalByte, 2).PadLeft(8, '0') + " ");
            }
            Console.WriteLine();

            Reverse(data);
            foreach (byte originalByte in data)
            {
                Console.Write(Convert.ToString(originalByte, 2).PadLeft(8, '0') + " ");
            }
            Console.WriteLine();
        }
	}
}
