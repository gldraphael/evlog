#tool "xunit.runner.console&version=2.2.0"
#addin "Cake.Docker&version=0.10.0"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var testDbContainerName = $"evlogtesdb-{Guid.NewGuid()}";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

const string sln = "./evlog.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("build")
    .Does(() =>
{
    DotNetCoreBuild(sln,
        new DotNetCoreBuildSettings
        {
            Configuration = configuration
        }
    );
});

Task("startdb")
    .Does(() =>
{
    DockerRun(settings: new DockerContainerRunSettings {
            Name = testDbContainerName,
            Env = new[] { "MYSQL_ROOT_PASSWORD=Pa5sw0rd" },
            Publish = new[] { "3307:3306" },
            Detach = true,
            Rm = true
        },
        image: "mysql:8.0.16",
        command: null, args: null);
});

Task("stopdb")
    .Does(() =>
{
    DockerStop(testDbContainerName);
});

Task("xunit")
    .IsDependentOn("startdb")
    .IsDependentOn("build")
    .Does(() =>
{
    var projects = GetFiles("./tests/**/*.csproj");
    foreach(var project in projects)
    {
        DotNetCoreTest(
            project.FullPath,
            new DotNetCoreTestSettings()
            {
                Configuration = configuration,
                NoRestore = true,
                NoBuild = true,
                ResultsDirectory = project.GetDirectory(),
                ArgumentCustomization = args => args.Append("--logger:trx;LogFileName=test_result.xml")
            }
        );
    }
    RunTarget("stopdb");
});

Task("docker-build")
    .Does(() =>
{
    DockerBuild(new DockerImageBuildSettings{
        Tag = new string[] {
            "gldraphael/evlog"
        },
        File = "src/Evlog.Web/Dockerfile"
    }, ".");
    DockerBuild(new DockerImageBuildSettings{
        Tag = new string[] {
            "gldraphael/evlog-self-contained"
        },
        Target = "self-contained",
        File = "src/Evlog.Web/Dockerfile"
    }, ".");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("xunit");

 Task("azure-pipelines")
    .IsDependentOn("xunit");

Task("travis")
    .IsDependentOn("docker-build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
