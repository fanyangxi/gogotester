using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GoGoTester.Common
{
    public class NewVersionChecker
    {
        public void CheckNewUpdate(Action<long, long> callBack)
        {
            try
            {
                var sourceUrl = @"https://raw.githubusercontent.com/azzvx/gogotester/2.3/GoGo%20Tester/bin/Release/ver";
                var req = WebRequest.Create(sourceUrl);
                req.BeginGetResponse(ar =>
                {
                    if (!ar.IsCompleted)
                        return;

                    var resps = req.EndGetResponse(ar).GetResponseStream();
                    if (resps == null)
                        return;

                    using (var sr = new StreamReader(resps))
                    {
                        var localVersion = Config.Version;
                        var remoteNewVersion = long.Parse(sr.ReadToEnd());
                        if (remoteNewVersion < localVersion)
                        {
                            callBack(localVersion, remoteNewVersion);
                        }
                        else
                        {
                            // Do nothing
                        }
                    }
                }, null);
            }
            catch
            {
                // Suppress the exceptions
            }
        }
    }
}
