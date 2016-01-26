using System;
using System.Collections.Generic;
using System.IO;

namespace Cafun_XML_Gen
{
    class Config
    {
        private static String CONFIG_FILE_NAME = "UserSettings.txt";
        private static String KEY_PREFIX = "SET ";
        private static String VALUE_PACKET = "\"";
        private static String FILE_DOES_NOT_EXIST = "File does not exist, check path.";
        private static char DELIMITER = ' ';
        /// <summary>
        /// contains Keys and Values of config file.
        /// </summary>
        public Dictionary<String, String> config { get; private set; }
        /// <summary>
        /// contains path of config file.
        /// </summary>
        public String path {get; private set; }
        /// <summary>
        /// if a failable function returns with false error will contain information about what happened, contains the LAST error.
        /// </summary>
        public String error { get; private set; }
        /// <summary>
        /// contains the number of errors occured in this object.
        /// </summary>
        public int error_count { get; private set; }
        /// <summary>
        /// default constructor, use when Path to config is still unclear or Config does not exist.
        /// </summary>
        public Config()
        {
            config = new Dictionary<string, string>();
            path = null;
            error = null;
            error_count = 0;
        }
        /// <summary>
        /// load constructor, takes a path (without filename) and calls the ReadConfig function. 
        /// </summary>
        /// <param name="path">String that contains path the folder of the file</param>
        /// <exception cref="System.Exception">Thrown when SetPath fails</exception>
        public Config(String path)
        {
            config = new Dictionary<string, string>();
            error = null;
            error_count = 0;
            if (!SetPath(path))
            {
                throw new Exception(error);
            }
            if (File.Exists(this.path))
                ReadConfig();
        }
        /// <summary>
        /// trys to read the config located at the path and adds keys and values to the Dictionary,
        /// invalid keys and values will be ignored but will increase the error counter.
        /// </summary>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool ReadConfig()
        {
            var backup = config;
            config = new Dictionary<string, string>();
            if (!File.Exists(path))
            {
                error = FILE_DOES_NOT_EXIST;
                error_count++;
                return false;
            }
            try
            {
                foreach (var line in File.ReadLines(path))
                {
                    if (line.StartsWith(KEY_PREFIX))
                    {
                        var list = line.Split(DELIMITER);
                        if (list.Length == 3)
                        {
                            if (!AddKey(list[1], list[2].Replace(DELIMITER.ToString(), String.Empty)))
                                error_count++;
                        }
                    }
                }
                return true;
            }
            catch (ArgumentException e)
            {
                //path is a zero-length string, contains only white space, or contains one or more invalid characters defined by the GetInvalidPathChars method.
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (DirectoryNotFoundException e)
            {
                //path is invalid (for example, it is on an unmapped drive).
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (FileNotFoundException e)
            {
                //The file specified by path was not found.
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (IOException e)
            {
                //An I/O error occurred while opening the file.
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                /*
                path specifies a file that is read-only.
                -or -
                This operation is not supported on the current platform.
                - or -
                path is a directory.
                - or -
                The caller does not have the required permission.
                */
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (System.Security.SecurityException e)
            {
                //The caller does not have the required permission.
                config = backup;
                error = e.ToString();
                error_count++;
                return false;
            }
        }
        /// <summary>
        /// trys to write a config file at the path and inserts all key,values inside.
        /// </summary>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool WriteConfig()
        {
            try
            {
                if (!Directory.Exists(Path.GetFullPath(path)))
                {
                    Directory.CreateDirectory(Path.GetFullPath(path));
                }
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                else
                {
                    File.Delete(path);
                    File.Create(path).Close();
                }
                String text = null;
                foreach (KeyValuePair<String, String> kv in config)
                {
                    text += KEY_PREFIX + DELIMITER + kv.Key + DELIMITER + kv.Value + "\n";
                }
                File.WriteAllText(path, text);
                return true;
            }
            catch (IOException e)
            {
                //An I/O error occurred while opening the file.
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                /*
                path specifies a file that is read-only.
                -or -
                This operation is not supported on the current platform.
                - or -
                path is a directory.
                - or -
                The caller does not have the required permission.
                */
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (ArgumentException e)
            {
                //path is a zero-length string, contains only white space, or contains one or more invalid characters defined by the GetInvalidPathChars method.
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (NotSupportedException e)
            {
                error = e.ToString();
                error_count++;
                return false;
            }
            catch (System.Security.SecurityException e)
            {
                //The caller does not have the required permission.
                error = e.ToString();
                error_count++;
                return false;
            }
        }
        /// <summary>
        /// adds new key, value pair to dicionary.
        /// </summary>
        /// <param name="key">String name of key.</param>
        /// <param name="value">String value of the key.</param>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool AddKey(String key, String value)
        {
            try
            {
                config.Add(key, value);
                return true;
            }
            catch (ArgumentException e)
            {
                error = e.ToString();
                error_count++;
                return false;
            }
        }
        /// <summary>
        /// deletes a given key from dictionary and calls the write function to save state.
        /// </summary>
        /// <param name="key">name of the key to delete.</param>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool DeleteKey(String key)
        {
            try
            {
                config.Remove(key);
                return true;
            }
            catch (ArgumentNullException e)
            {
                error = e.ToString();
                error_count++;
                return false;
            }
        }
        /// <summary>
        /// checks if the given path is valid and then changes path of config accordingly.
        /// </summary>
        /// <param name="path">path where the file should be located (without filename).</param>
        /// <returns>true in sucess, false otherwise.</returns>
        public bool SetPath(String path)
        {
            try
            {
                this.path = Path.Combine(path, CONFIG_FILE_NAME);
                return true;
            }
            catch (ArgumentException e)
            {
                error = e.ToString();
                error_count++;
                return false;
            }      
        }
    }
}
