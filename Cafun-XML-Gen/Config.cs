using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    class Config
    {
        /// <summary>
        /// contains Keys and Values of config file.
        /// </summary>
        public Dictionary<String, String> config { get; private set; }
        /// <summary>
        /// contains path of config file.
        /// </summary>
        public String path {get; private set; }
        /// <summary>
        /// default constructor, use when Path to config is still unclear or Config does not exist.
        /// </summary>
        public Config()
        {

        }
        /// <summary>
        /// load constructor, takes a path and calls the ReadConfig function. 
        /// </summary>
        /// <param name="path"></param>
        public Config(String path)
        {

        }
        /// <summary>
        /// trys to read the config located at the path and adds keys and values to the Dictionary.
        /// </summary>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool ReadConfig()
        {
            return false;
        }
        /// <summary>
        /// trys to write a config file at the path and inserts all key,values inside.
        /// </summary>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool WriteConfig()
        {
            return false;
        }
        /// <summary>
        /// adds new key, value pair to dicionary (checks for invalid inserts, that may damage config file).
        /// </summary>
        /// <param name="key">String name of key.</param>
        /// <param name="value">String value of the key.</param>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool AddKey(String key, String value)
        {
            return false;
        }
        /// <summary>
        /// deletes a given key from dictionary and calls the write function to save state.
        /// </summary>
        /// <param name="key">name of the key to delete.</param>
        /// <returns>true on sucess, false otherwise.</returns>
        public bool DeleteKey(String key)
        {
            return false;
        }
        /// <summary>
        /// checks if the given path is valid and then changes path of config accordingly.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetPath(String path)
        {
            return false;
        }
    }
}
