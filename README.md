# XamFormsMvxTemplate

This is a project to build a Visual Studio 2015 extension to help you start developing with Xamarin.Forms and MvvmCross.

You can download the extension from [the Visual Studio gallery] (https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936 "Visual Studio Extension").

## Requirements

The projects generated require a reference to the SQLite libraries, and because of issues with the latest version of Nuget, the UWP project cannot get that reference from the MvvmCross SQLite package. __In order to be able to resolve this reference, you need to install the SQLite for Universal Windows Platform extension.__ You can download the extension from [here] (https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936 "SQLite for Universal Windows Platform"). 

## What to expect

After installing the extension, when creating a new project in Visual Studio, you will be able to select a new template: Xamarin Forms with MvvmCross Solution Template. This will create the following projects:

* A Portable Class Library that will contain the Xamarin.Forms UI files, the View Models and a basic abstract repository class to work with the SQLite database.
* An Android project
* An iOS project
* An Universal Windwos Platform project
* An UITest project
* An UnitTest project

Other small features that can be found in the project are:

* Localization
* (will continue to add more interesting stuff)
