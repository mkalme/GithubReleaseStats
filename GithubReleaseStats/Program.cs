using System;
using Octokit;
using System.Threading.Tasks;

namespace GithubReleaseStats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = "GoldenTadpole";
            string repository = "Mapee";

            var github = new GitHubClient(new ProductHeaderValue("GitHubReleaseLister"));
            var releases = github.Repository.Release.GetAll(username, repository).Result;

            Console.WriteLine($"List of releases for {username}/{repository}:");
            foreach (var release in releases)
            {
                Console.WriteLine($"- Name: {release.Name}");
                Console.WriteLine($"  Tag: {release.TagName}");
                Console.WriteLine($"  Published at: {release.PublishedAt}");
                Console.WriteLine($"  Assets:");
                foreach (var asset in release.Assets)
                {
                    Console.WriteLine($"    - {asset.Name}: {asset.DownloadCount}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}