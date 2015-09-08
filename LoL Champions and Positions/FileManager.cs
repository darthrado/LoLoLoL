/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LoL_Champions_and_Positions
{
    public abstract class FileManager<Template>
    {
        protected Queue<string> saveLines;
        public int LineCount { get { return saveLines.Count; } }

        protected FileManager()
        {
            saveLines = new Queue<string>();

        }

        abstract public List<Template> ExportLines();
        abstract public bool ImportLines(List<Template> List);
        
        public bool saveToFile(string _filename)
        {
            if (saveLines.Count <= 0)
            {
                return false;
            }

            string newLine;
		    FileStream saveFile;

		    List<byte[]> seriList = new List<byte[]>();
		    saveFile = new FileStream(_filename,FileMode.Create);
		    BinaryFormatter serializator = new BinaryFormatter();

		    byte[] Key = null;
		    byte[] IV = null;

		    //write data
		    byte[] Encryption = AES.EncryptStringToByte("Initialize",ref Key,ref IV);
		    seriList.Add(Key);
		    seriList.Add(IV);

		    while(saveLines.Count>0)
		    {
                newLine = saveLines.Dequeue();

                Encryption = AES.EncryptStringToByte(newLine,ref Key,ref IV);
			    seriList.Add(Encryption);
		    }
		    serializator.Serialize(saveFile,seriList);
		    saveFile.Close();
		    //close stream
		    return true;
        }

        public bool getFromFile(string filename)
        {
		    List<byte[]> deSeriList = null;

		    FileStream sr = new FileStream(filename,FileMode.Open);
		    BinaryFormatter formatter = new BinaryFormatter();

		    string ReadLine;
            bool enumFlag = false;

		    try
		    {
                deSeriList = (List<byte[]>)formatter.Deserialize(sr);
		    }
		    catch (SystemException) 
		    {
			    sr.Close();
			    return false;
		    }

            List<byte[]>.Enumerator e = deSeriList.GetEnumerator();


            enumFlag=e.MoveNext();
                byte[] Key = e.Current;
                enumFlag = e.MoveNext();
                byte[] IV = e.Current;

                while (e.MoveNext())
                {
                    ReadLine = AES.DecryptStringFromByte(e.Current, Key, IV);

                    saveLines.Enqueue(ReadLine);
                }
                sr.Close();
            return true;
        }
    }
}*/
