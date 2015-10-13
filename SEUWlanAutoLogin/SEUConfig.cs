using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SEUWlanAutoLogin
{
    class SEUConfig
    {
        public string StuID;
        public string Pwd;
        public bool bSavePwd;
        public bool bAutoLog;
        private string jsonPath;

        public SEUConfig()
        {
            jsonPath = "SEUConfig.json";
        }

        public bool SaveToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            try 
            {
                File.WriteAllText(jsonPath, json);
            }
            catch { return false; }
            return true;
        }

        public void CopyToThis(SEUConfig conf)
        {
            this.StuID = conf.StuID;
            this.Pwd = conf.Pwd;
            this.bAutoLog = conf.bAutoLog;
            this.bSavePwd = conf.bSavePwd;
        }
        public void ReadConfig()
        {
            if(File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                SEUConfig newConfig = JsonConvert.DeserializeObject<SEUConfig>(json);
                this.CopyToThis(newConfig);
            }
            else
            {
                this.StuID = "0";
            }
        }
    }
}
