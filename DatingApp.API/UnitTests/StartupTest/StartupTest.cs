using System;
using System.IO;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.StartupTest
{
    [TestClass]
    public class StartupTest
    {
        private IConfigurationRoot Configuration;

        [TestMethod]
        public void teste()
        {
            var diretorio = BuscarDiretorioApi();

            var environment = CreateEnvironment(diretorio, "Development");

            var builder = BuildConfiguration(environment);

            Configuration = builder.Build();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            //connectionString.Should().Be("{SGS_WEB_ORACLE_PASS}");
        }

        private string BuscarDiretorioApi()
        {
            var diretorio = string.Empty;
            string diretorioCorrente = Environment.CurrentDirectory;
            var diretorioPaiCorrente = Directory.GetParent(diretorioCorrente).Parent;
            if (diretorioPaiCorrente != null)
            {
                var diretorioAnterior = diretorioPaiCorrente;
                while (diretorioAnterior != null && diretorioAnterior.Name != "DatingApp.API")
                {
                    var diretorioPai = Directory.GetParent(diretorioAnterior.FullName).Parent;
                    diretorioAnterior = diretorioPai;
                }

                diretorio = diretorioAnterior.FullName;
            }

            return $"{diretorio}\\DatingApp.Api";
        }

        private HostingEnvironment CreateEnvironment(string diretorioPath, string environment)
        {
            return new HostingEnvironment
            {
                ApplicationName = "DatingApp.API",
                ContentRootPath = diretorioPath,
                EnvironmentName = environment,
                ContentRootFileProvider = new PhysicalFileProvider(diretorioPath),
                WebRootFileProvider = new NullFileProvider()
            };
        }

        private IConfigurationBuilder BuildConfiguration(HostingEnvironment environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
        }
    }
}
