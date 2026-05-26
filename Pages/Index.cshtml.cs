using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpFileSystem.Pages
{
    public class IndexModel : PageModel
    {
        public DirectoryInfo CurrentDirectory { get; private set; }

        public IActionResult OnGet(string path = "/home/", string? file = null)
        {
            if(file != null && System.IO.File.Exists(file))
            {
                return File(System.IO.File.OpenRead(file),"application/octet-stream",Path.GetFileName(file));
            }
            else
            {
                Console.WriteLine(path);
                if(Directory.Exists(path))
                {
                    CurrentDirectory = new DirectoryInfo(path);
                }
                else CurrentDirectory = new DirectoryInfo("/home/");

                return Page();
            }
        }

        public void OnPost(string path)
        {
            Console.WriteLine(path);
            if(Directory.Exists(path))
            {
                CurrentDirectory = new DirectoryInfo(path);
            }
            else CurrentDirectory = new DirectoryInfo("/home/");
        }
    }
}
