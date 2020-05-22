using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace count_wc
{
    class Count
    {
        int konggenum;//空格及制表符
        int charnum;//字符数 = 总个数—空格、制表符数
        int wordsnum;
        int lines;
        string sFilename;

        public string SFilename
        {
            get { return sFilename; }
            set { sFilename = value; }
        }

        //属性
        public int Konggenum
        {
            get { return konggenum; }
            set { konggenum = value; }
        }


        public int Charnum
        {
            get { return charnum; }
            set { charnum = value; }
        }


        public int Wordsnum
        {
            get { return wordsnum; }
            set { wordsnum = value; }
        }


        public int Lines
        {
            get { return lines; }
            set { lines = value; }
        }


        public Count()
        {

            konggenum = 0;
            charnum = 0;
            wordsnum = 0;
            lines = 0;


        }

        /// <summary>
        /// 进入文件
        /// </summary>
        /// <param name="sFilename"></param>
        public void infile(string sFilename)
        {
            this.sFilename = sFilename;
            int length = 0;//总长度
                           // count.RunCmd(@"C:\WINDOWS\system32\cmd.exe ","aa");

            try
            {

                //            FileStream file = new FileStream(sFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(sFilename, Encoding.Default);

                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    lines++;
                    perLineWord(str);

                    // perLineWord(str);                
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("无此文件");



            }
            charnum = length - konggenum;
            codeline = lines - nullline - noteline;

        }
        /// <summary>
        /// 文件中一行的情况
        /// </summary>
        /// <param name="str"></param>
        public void perLineWord(string str)
        {
            //            int tempkongge = 0;
            //          int tempwords = 0;
            int i = 0; StreamReader sr = new StreamReader(sFilename, Encoding.Default);
            while (str[i] == ' ' || str[i] == '\t')//去开头空格
            {
                konggenum++;
                //                tempkongge++;

                i++;
                if (i == str.Length) break;
            }
            while (i < str.Length)
            {

                //单词是以字母开头，字母、数字、_、组合的
                if (('a' <= str[i] && str[i] <= 'z') || ('A' <= str[i] && str[i] <= 'Z'))
                {
                    i++;


                    while (('a' <= str[i] && str[i] <= 'z') || ('A' <= str[i] && str[i] <= 'Z') || ('0' <= str[i] && str[i] <= '9') || str[i] == '_')
                    {

                        i++;
                        if (i == str.Length) break;
                    }
                    wordsnum++;
                    //                    tempwords++;

                }
                else if (str[i] == ' ' || str[i] == '\t')
                {
                    konggenum++;
                    //                   tempkongge++;
                    i++;

                }

                else i++;
            }
            //            Console.WriteLine("字符数{0},,,{1}", i - tempkongge, tempwords);
        }


    }


}