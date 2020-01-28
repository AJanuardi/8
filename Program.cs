using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace app7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var launchOptions = new LaunchOptions()
            {   
                Headless = false
            };
            using (var browser = await Puppeteer.LaunchAsync(launchOptions))
            using (var page = await browser.NewPageAsync())
            {
            int counter = 1;
            string path = "D:/Users/bsi50130/Desktop/app7/";
            string[] file = Directory.GetFiles(path);
            foreach(string x in file)
            {
                if (x.Substring(12)==Convert.ToString(counter))
                {
                    counter++;
                    await page.GoToAsync("https://www.google.com");
                    await page.ScreenshotAsync("screenshot--"+counter+".png");

                }
            }
            }
        }
    }
}
