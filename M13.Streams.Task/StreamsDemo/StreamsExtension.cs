using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] byteArray;
            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                byteArray = new byte[readStream.Length];
                readStream.Read(byteArray, 0, byteArray.Length);               
            }

            using (FileStream writeStream = new FileStream(destinationPath, FileMode.Open))
            {
                foreach(byte b in byteArray)
                {
                    writeStream.WriteByte(b);
                }
            }

            return byteArray.Length;
        }
        
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            string readingResult = string.Empty;

            using (StreamReader sr = new StreamReader(sourcePath, Encoding.UTF8))
            {
                readingResult = sr.ReadToEnd();
            }

            byte[] readingResultBytes = Encoding.UTF8.GetBytes(readingResult);
            byte[] writingBytes = new byte[readingResultBytes.Length];

            using (MemoryStream ms = new MemoryStream(readingResultBytes, 0, readingResultBytes.Length))
            {
                ms.Write(readingResultBytes, 0, readingResultBytes.Length);
                writingBytes = ms.ToArray();
            }

            char[] writingChars = Encoding.UTF8.GetChars(writingBytes);

            using (StreamWriter sw = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                foreach (char c in writingChars)
                {
                    sw.Write(c);
                }
            }

            return writingBytes.Length;
        }

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] byteArray;
            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                byteArray = new byte[readStream.Length];
                readStream.Read(byteArray, 0, byteArray.Length);
            }

            using (FileStream writeStream = new FileStream(destinationPath, FileMode.Open))
            {
                writeStream.Write(byteArray, 0, byteArray.Length);
            }

            return byteArray.Length;
        }

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            string readingResult = string.Empty;

            using (StreamReader sr = new StreamReader(sourcePath, Encoding.UTF8))
            {
                readingResult = sr.ReadToEnd();
            }

            byte[] readingResultBytes = Encoding.UTF8.GetBytes(readingResult);
            byte[] writingBytes = new byte[readingResultBytes.Length];

            using (MemoryStream ms = new MemoryStream(readingResultBytes, 0, readingResultBytes.Length))
            {
                ms.Write(readingResultBytes, 0, readingResultBytes.Length);
                writingBytes = ms.ToArray();
            }

            char[] writingChars = Encoding.UTF8.GetChars(writingBytes);

            using (StreamWriter sw = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                sw.WriteLine(writingChars);
            }

            return writingBytes.Length;
            throw new NotImplementedException();
        }

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            throw new NotImplementedException();
        }

        #endregion
        #endregion

        #region Private members
        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} can't be equal to null or empty!");
            }

            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} can't be equal to null or empty!");
            }

            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} isn't exist on this computer!");
            }

            if (!File.Exists(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} isn't exist on this computer!");
            }
        }

        #endregion
        #endregion
    }
}