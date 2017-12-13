#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();


BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./",
                            title: "Autotask",
                            repositoryOwner: "tjackadams",
                            repositoryName: "autotaskoperations",
                            appVeyorAccountName: "tjackadams",
							testDirectoryPath: "./test",
							nuspecFilePath: "./nuspec/nuget/Autotask.Operations.nuspec");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/Autotask/**/*.AssemblyInfo.cs",  BuildParameters.RootDirectoryPath + "/test/Autotask.Tests/**/*.AssemblyInfo.cs" },
                            testCoverageFilter: "+[*]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();