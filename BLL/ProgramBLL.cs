using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public static class ProgramBLL
    {

        public async static Task<string> CheckVersion()
        {
            var github = new GitHubClient(new ProductHeaderValue("SURU"));
            var tags = await github.Repository.GetAllTags("jonaselan", "SURU");
            var t = tags.FirstOrDefault();
            if (t == null) { return Program.Version; }
            return t.Name;
        }

        public async static Task<bool> IsUpToDate() {
            Program.OnlineVersion = await CheckVersion();
            if (Program.OnlineVersion == Program.Version) { return true; }
            return false;
        }
    }
}
