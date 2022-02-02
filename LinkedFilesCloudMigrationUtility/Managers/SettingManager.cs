using System.IO;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace LinkedFilesCloudMigrationUtility.Helper
{

    public class SettingManager
    {
        public static string GetThirdPartyAppKeysSetting(string section, string nodeName)
        {
            var node = GetThirdPartyAppKeysSection(section)?.Element(nodeName);
            if (node != null)
                return node.Value;
            return "";
           // return GetThirdPartyAppKeysSection(section).Element(nodeName).Value;
        }

        private static XElement GetThirdPartyAppKeysSection(string section)
        {
            return GetThirdPartyAppKeysSettingFile().Element("BQECoreThirdPartyAppKeys").Element(section);
        }

        private static XDocument GetThirdPartyAppKeysSettingFile()
        {
            return XDocument.Load(GetFilePath("Setting", "BQECoreThirdPartyAppKeys.xml"));
        }

        public static string GetFilePath(string foldername, string fileName)
        {

            return Path.Combine(SettingManager.MapPath(), foldername, fileName);

        }

        public static string GetDBSection(string nodename)
        {
            return XDocument.Load(GetFilePath("Setting", "setting.xml")).Element("setting").Element("AppSettings").Element(nodename).Value;
        }


        private static string MapPath()
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);

            return System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\BQECoreBusinessLogic\\bin\\", "\\BQECoreAPI\\");
        }

        public static string ReadFile(string fileName)
        {

            var filePath = GetFilePath("Setting", fileName);

            if (File.Exists(filePath))
                return File.ReadAllText(filePath);

            return string.Empty;
        }


    }
}