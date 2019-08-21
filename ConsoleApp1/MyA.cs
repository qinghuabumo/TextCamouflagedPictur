using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPHIDE
{
    public class MyA
    {

        // Token: 0x06000015 RID: 21 RVA: 0x00002924 File Offset: 0x00002924
        public static byte[] Myh(byte[] data)
        {
            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num2 = (int)MyA.Myg(num++);
                int num3 = (int)data[i];
                num3 = (int)Program.e((byte)num3, (byte)num2);
                num3 = (int)Program.b((byte)num3, 7);

                int num4 = (int)MyA.Myg(num++);
                num3 = (int)Program.e((byte)num3, (byte)num4);
                num3 = (int)Program.d((byte)num3, 3);
                array[i] = (byte)num3;
            }
            return array;
        }
        public static byte[] Myh2(byte[] data)
        {
            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num3 = (int)data[i];
                num += 2;

                int num4 = (int)MyA.Myg(num - 1);
                num3 = (int)Program.d((byte)num3, 5);
                num3 = (int)Program.e((byte)num3,(byte)num4);


                int num2 = (int)MyA.Myg(num - 2);
                num3 = (int)Program.b((byte)num3, 1);
                num3 = (int)Program.e((byte)num3,(byte)num2);
                
                array[i] = (byte)num3;
            }
            return array;
        }

        // Token: 0x06000014 RID: 20 RVA: 0x000028F0 File Offset: 0x000028F0
        public static byte Myg(int idx)
        {
            byte b = (byte)((idx + 1) * 309030853);
            byte k = (byte)((idx + 2) * 209897853);
            return Program.e(b, k);
        }
        // Token: 0x06000014 RID: 20 RVA: 0x000028F0 File Offset: 0x000028F0
        public static byte Myg1(int idx)
        {
            byte b = (byte)((idx - 1) / 309030853);
            byte k = (byte)((idx - 2) / 209897853);
            return Program.e(b, k);
        }
        public static byte[] i(Bitmap bm, byte[] data)
        {
            int num = 0;
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    bool flag = num > data.Length - 1;
                    if (flag)
                    {
                        break;
                    }
                    Color pixel = bm.GetPixel(i, j);

                    int num1 = pixel.R & 7;
                    int num2 = (pixel.G & 7) << 3;
                    int num3 = (pixel.B & 7) << 6;

                    data[num] = (byte)(num1 + num2 + num3);
                    //int red = (pixel.R & 248) | (data[num] & 7); //前五位  后三位   0-2
                    //int green = (pixel.G & 248) | (data[num] >> 3 & 7);  //3-5
                    //int blue = (pixel.B & 252) | (data[num] >> 6 & 3); // 6-7
                    //Color color = Color.FromArgb(0, red, green, blue);
                    //bm.SetPixel(i, j, color);
                    num += 1;
                }
            }
            return data;
        }
        public static byte[] dec(Bitmap bm, byte[] array)
        {
            int num = 0;
            array = new byte[bm.Width * bm.Height];
            for (int i = 0; i < bm.Width; i++)
            {
                int num2 = 0;
                while (num2 < bm.Height && num <= array.Length - 1)
                {
                    Color pixel = bm.GetPixel(i, num2);
                    int num3 = (int)(pixel.R & 7);
                    int num4 = (int)(pixel.G & 7) << 3;
                    int num5 = (int)(pixel.B & 3) << 6;
                    array[num] = (byte)(num3 + num4 + num5);
                    num++;
                    num2++;
                }
            }
            return array;
        }
    }
}
