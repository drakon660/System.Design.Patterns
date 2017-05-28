#addin "Cake.Incubator"

var destination = Argument("destination", "F:\\publish");
var target = Argument("target", "Compile");

Task("Compile")
  .Does(() =>
{
  Information("Compiling");
  MSBuild("./System.Design.Patterns/System.Design.Patterns.csproj", new MSBuildSettings()
  .WithProperty("OutDir", destination)
  .WithProperty("DeployOnBuild", "true")
  .WithProperty("Configuration", "Release")
  .WithProperty("PackageAsSingleFile", "true")
  .WithProperty("Verbosity", "Verbosity.Minimal")
  .WithProperty("ToolVersion", "MSBuildToolVersion.VS2015")
  .WithProperty("PlatformTarget", "PlatformTarget.MSIL")
  .WithProperty("SkipInvalidConfigurations", "true"));
});

Task("Remove PDB")
    .Description("Removing all but dll files from" + destination)
    .Does(() =>
{        
    var files = GetFiles(destination + "\\*.pdb");
    DeleteFiles(files);
});

Task("CleanDirectory")
    .Description("cleaning directory " + destination)
    .Does(() =>
{        
    CleanDirectory(destination);
});


RunTarget(target);