using Octokit;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public static class Program
    {

        public async static Task<string> CheckVersion()
        {
            var github = new GitHubClient(new ProductHeaderValue("SURU"));
            var tags = await github.Repository.GetAllTags("jonaselan", "SURU");
            var t = tags.FirstOrDefault();
            if (t == null) { return DTO.Program.Version; }
            return t.Name;
        }

        public async static Task<bool> IsUpToDate() {
            DTO.Program.OnlineVersion = await CheckVersion();
            if (DTO.Program.OnlineVersion == DTO.Program.Version) { return true; }
            return false;
        }
    }
}
