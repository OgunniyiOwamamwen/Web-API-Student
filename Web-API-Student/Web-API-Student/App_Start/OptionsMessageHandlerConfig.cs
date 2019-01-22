using System;
using System.Web.Http;

namespace Web_API_Student
{
    public static class OptionsMessageHandlerConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            config.MessageHandlers.Add(new OptionsHttpMessageHandler());
        }
    }
}
