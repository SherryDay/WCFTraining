using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using Microsoft.Web.Administration;

namespace AutomationIIS
{
    public class IISFolderHandler
    {
        private static string basePath = string.Empty;

        public static void AddIUSRToWwwrootFolder(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.AddAccessRule(new FileSystemAccessRule(@"IUSR",FileSystemRights.ReadAndExecute,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow));

            directoryInfo.SetAccessControl(directorySecurity);
        }

        public static void SetBindings()
        {
            ServerManager serverManager = new ServerManager();
            Site site = serverManager.Sites["Default Web Site"];

            string bindingInformation = "*:443";

            foreach(Binding binding in site.Bindings)
            {
                if (binding.BindingInformation == bindingInformation)
                {
                    site.Bindings.Remove(binding);
                    break;
                }
            }

            site.Bindings.Add(bindingInformation, null, "");
            serverManager.CommitChanges();
        }

        public static void DeployService(string strDirPath)
        {
            basePath = strDirPath;

            if (basePath.Substring(basePath.Length-1, 1) == "\"")
            {
                basePath = basePath.Substring(0, basePath.Length - 1);
            }


        }
    }
}
