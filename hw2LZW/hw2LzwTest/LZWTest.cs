using NUnit.Framework;
using System.IO;

namespace hw2LzwTest
{
    [TestFixture]
    public class Tests
    {
        private bool Compare(string path1, string path2)
        {
            using FileStream file1 = File.OpenRead(path1);
            using FileStream file2 = File.OpenRead(path2);
            if (file1.Length != file2.Length)
            {
                return false;
            }
            for (int i = 0; i < file1.Length; ++i)
            {
                if (file1.ReadByte() != file2.ReadByte())
                {
                    return false;
                }
            }
            return true;
        }

        [TestCase]
        public void LZWWithTxt()
        {
            string path1 = "..\\..\\..\\TestTxt.txt";
            string path2 = "..\\..\\..\\TestTxtCopy.txt";
            hw2LZW.LZW.Compress(path1);
            hw2LZW.LZW.Decompress(path1 + ".zipped");
            File.Delete(path1 + ".zipped");
            Assert.IsTrue(Compare(path1, path2));
        }

        [TestCase]
        public void LZWWithImg()
        {
            string path1 = "..\\..\\..\\TestImg.jpg";
            string path2 = "..\\..\\..\\TestImgCopy.jpg";
            hw2LZW.LZW.Compress(path1);
            hw2LZW.LZW.Decompress(path1 + ".zipped");
            File.Delete(path1 + ".zipped");
            Assert.IsTrue(Compare(path1, path2));
        }

    }
}