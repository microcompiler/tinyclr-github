# Sample TinyCLR Project

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
  <PropertyGroup>
    <!-- Nuget Pack Properties -->
    <RuntimeIdentifier>win</RuntimeIdentifier>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <IncludeSymbols>true</IncludeSymbols>
    <SymbolPackageFormat>snupkg</SymbolPackageFormat>
    <PackageId>$(AssemblyName)</PackageId>
    <AssemblyTitle>$(AssemblyName)</AssemblyTitle>
    <VersionPrefix>1.0.0</VersionPrefix>
    <Version Condition=" '$(Version)' == '' and '$(VersionSuffix)' != '' ">$(VersionPrefix)-$(VersionSuffix)</Version>
    <Version Condition=" '$(Version)' == '' ">$(VersionPrefix)</Version>
    <Authors>Microcompiler</Authors>
    <Company>$(AssemblyCompany)</Company>
    <Description>Simple TinyCLR Cube Library</Description>
    <PackageTags>TinyCLR, firmware, iot</PackageTags>
    <PackageProjectUrl>https://github.com/microcompiler/</PackageProjectUrl>
    <RepositoryUrl>https://github.com/microcompiler/tinyclr</RepositoryUrl>
    <PackageLicenseFile>LICENSE.md</PackageLicenseFile>
    <PackageIcon>logo.png</PackageIcon>
    <NoWarn>NU5105</NoWarn>
    <!-- Nuget Pack Properties -->
  </PropertyGroup>
    <ItemGroup>
    <PackageReference Include="GHIElectronics.TinyCLR.Core" Version="1.0.0" />
    <PackageReference Include="Microsoft.SourceLink.GitHub" Version="1.0.0" PrivateAssets="all" />
    <PackageReference Include="NuGet.Build.Tasks.Pack" Version="5.5.0-preview.1.6319">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
  <!-- Embedded files -->
  <ItemGroup>
    <None Include="..\..\LICENSE.md" Link="LICENSE.md">
      <Pack>True</Pack>
      <PackagePath>
      </PackagePath>
    </None>
  </ItemGroup>
  <ItemGroup>
    <None Include="..\..\images\logo.png">
      <Pack>True</Pack>
      <PackagePath>
      </PackagePath>
    </None>
  </ItemGroup>
  <!-- Embedded files -->
  ```
  