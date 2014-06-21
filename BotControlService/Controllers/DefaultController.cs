using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Web.Http;
using Bot.Shared;


namespace BotFair.ControlService.Controllers
{
    public class DefaultController : ApiController
    {
        private IBotServer server;

        public DefaultController()
        {
            string ipcPort = System.Configuration.ConfigurationManager.AppSettings["ipc_port"];
            server = (IBotServer)Activator.GetObject(typeof(IBotServer), "ipc://" + ipcPort + "/botserver/o");
        }
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public int GetState()
        {

            return server.GetState();

        }

        [HttpGet]
        public string StartProcess()
        {

            char[] chars = { 'g', 'e', 'g', 'e', 'n', 'g', 'i', 'f', 't' };

            SecureString pass = new SecureString();
            foreach (char ch in chars)
                pass.AppendChar(ch);


            var process = new System.Diagnostics.Process
            {
                
                StartInfo =
                {
                    FileName =
                        System.Configuration.ConfigurationManager.AppSettings["process"] +
                        "BotFair.exe",
                    WorkingDirectory =
                        System.Configuration.ConfigurationManager.AppSettings["process"],
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    //LoadUserProfile = true,
                    WindowStyle = ProcessWindowStyle.Maximized,
                   
                    //UserName = "worker",
                    //Password = pass,
                    //RedirectStandardError = true,
                    //RedirectStandardOutput = true


                }
               
            };


            bool success = process.Start();

            process.WaitForExit();
            var msg = process.StandardError.ReadToEnd();
            var msg2 = process.StandardOutput.ReadToEnd();
            return "OK";

        }

        // POST api/values

        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}