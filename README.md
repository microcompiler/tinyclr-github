# Sample Dotnet Core TinyCLR Project

[![Build Status](https://img.shields.io/github/workflow/status/microcompiler/tinyclr-github/Build%20CI?style=flat-square)](https://github.com/microcompiler/tinyclr-github/actions)

This repo contains a sample Visual Studio project leveraging github actions to build and publish TinyCLR OS libraries.  Automated action features include:

* Continious build action
* Release and publish action
* [Symbol Packages](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages-snupkg) allowing an improved debugging experience
* Embedded IntelliSense code-completion file
* Embedded [Source Link](https://github.com/dotnet/sourcelink/blob/master/README.md) source code debugging
* Self-contained NuGet Packages include logo and licenses files

## Github Actions

* Continuous Integration (CI) Build Action - [.github/workflows/build.yml](https://github.com/microcompiler/tinyclr-github/blob/master/.github/workflows/build.yml)

* Release and Publish Action - [.github/workflows/release.yml](https://github.com/microcompiler/tinyclr-github/blob/master/.github/workflows/release.yml)

## Required CSPROJ file settings

```xml
 <Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net452</TargetFramework>
    <FrameworkPathOverride>$(NugetPackagesPath)\.nuget\packages\ghielectronics.tinyclr.core\1.0.0\</FrameworkPathOverride>
    <DisableImplicitFrameworkReferences>true</DisableImplicitFrameworkReferences>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="GHIElectronics.TinyCLR.Core" Version="1.0.0" PrivateAssets="all" />
    <PackageReference Include="Microsoft.SourceLink.GitHub" Version="1.0.0" PrivateAssets="all" />
  </ItemGroup>
</Project>
```
  
### Required Directory.Build.props file settings

```xml
  <Project>
  <!-- Nuget Pack Properties -->
  <PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <IncludeSymbols>false</IncludeSymbols>
    <SymbolPackageFormat>snupkg</SymbolPackageFormat>
    <AssemblyVersion>1.0.6.0</AssemblyVersion>
    <FileVersion>1.0.6.0</FileVersion>
    <VersionPrefix>1.0.0</VersionPrefix>
    <Version Condition=" '$(Version)' == '' and '$(VersionSuffix)' != '' ">$(VersionPrefix)-$(VersionSuffix)</Version>
    <Version Condition=" '$(Version)' == '' ">$(VersionPrefix)</Version> 
    <GenerateAssemblyInfo>true</GenerateAssemblyInfo>
    <AssemblyVersion>$(VersionPrefix).0</AssemblyVersion>
    <FileVersion>$(VersionPrefix).0</FileVersion>
    <Authors>Microcompiler</Authors>
    <Company>Bytewizer Inc.</Company>
    <RepositoryUrl>https://github.com/microcompiler/tinyclr-github</RepositoryUrl>
    <PackageId>$(AssemblyName)</PackageId>
    <PackageTags>TinyCLR TinyCLROS</PackageTags>
    <PackageLicenseFile>LICENSE.md</PackageLicenseFile>
    <PackageIcon>logo.png</PackageIcon>
    <NoWarn>NU5105</NoWarn>  
  </PropertyGroup>
  <!-- Nuget Pack Properties -->
  <!-- Embedded files -->
  <ItemGroup>
    <None Include="..\..\LICENSE.md" Pack="true" PackagePath="$(PackageLicenseFile)"/>
    <None Include="..\..\images\logo.png" Pack="true" PackagePath="\"/>
  </ItemGroup>
  <!-- Embedded files -->  
</Project>
```