using System;
using System.Collections.Generic;

namespace CountProg_for_Wokoto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            System.IO.StreamReader sr = new System.IO.StreamReader("一覧.csv");
            string s = sr.ReadLine();
            int count = 0;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            Dictionary<string, int> dic_keijo = new Dictionary<string, int>();
            int[,] xy = new int[7, 7];
            System.IO.StreamWriter[,] sw_L = new System.IO.StreamWriter[7, 7];

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    xy[x, y] = 0;
                    string file ="xy\\"+ (x-3).ToString() + "_" + (y-3).ToString() + ".txt";
                    sw_L[x,y] = new System.IO.StreamWriter(file);
                }
            }
            System.IO.StreamWriter sw_bug = new System.IO.StreamWriter("形状が空白のもの.txt");

            while ((s = sr.ReadLine()) != null)
            {
                string[] ss = s.Split(',');
                //ss[0]　書誌名 ss[1]　壺 ss[2] 読み　ss[3] 形状　ss[4]　X　ss[5]　Y 　ss[6] 書誌ID

                if (dic.ContainsKey(ss[2]) == true) { dic[ss[2]]++; }
                else { dic[ss[2]] = 1; }
                if (dic_keijo.ContainsKey(ss[3]) == true) { dic_keijo[ss[3]]++; }
                else { dic_keijo[ss[3]] = 1; }
                if (ss[3] == "")
                {
                    Console.WriteLine(s);
                    sw_bug.WriteLine(s);
                }
                //座標ごとの個数カウント-3から+3までの範囲なので、配列0，0～7．7までに入れるために取得した値に+3して配列に入れ込む。
                int x, y;
                x = int.Parse(ss[4]);
                y = int.Parse(ss[5]);
                x = x + 3;
                y = y + 3;
                xy[x, y]++;
                //各位置の一覧を出力するためのコマンド
                sw_L[x, y].WriteLine(s);


            }
            sw_bug.Close();
            System.IO.StreamWriter sw = new System.IO.StreamWriter("out.txt");
            foreach (var kv in dic)
            {
                Console.WriteLine($"{kv.Key},{kv.Value}");
                sw.WriteLine($"{kv.Key},{kv.Value}");
            }
            sw.Close();

            System.IO.StreamWriter sw_k = new System.IO.StreamWriter("out_keijo.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            foreach (var kv in dic_keijo)
            {
                Console.WriteLine($"{kv.Key},{kv.Value}");
                sw_k.WriteLine($"{kv.Key},{kv.Value}");

            }
            sw_k.Close();

            System.IO.StreamWriter sw_c = new System.IO.StreamWriter("out_カウント.txt", false, System.Text.Encoding.GetEncoding("utf-8"));
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    sw_c.Write(xy[x, y] + ",");
                    Console.Write(xy[x, y] + ",");
                    sw_L[x, y].Close();
                }
                sw_c.WriteLine();
                Console.WriteLine();
            }
            sw_c.Close();


        }
    }
}
