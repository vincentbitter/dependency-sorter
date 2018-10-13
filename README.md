[![Build status](https://ci.appveyor.com/api/projects/status/jfv6i6p23piyw6i0?svg=true)](https://ci.appveyor.com/project/vincentbitter/dependency-sorter)
[![codecov](https://codecov.io/gh/vincentbitter/dependency-sorter/branch/master/graph/badge.svg)](https://codecov.io/gh/vincentbitter/dependency-sorter)
[![NuGet](https://img.shields.io/nuget/v/DependencySorter.svg)](https://www.nuget.org/packages/DependencySorter/)
[![NuGet](https://img.shields.io/nuget/dt/DependencySorter.svg)](https://www.nuget.org/packages/DependencySorter/)


# DependencySorter
Load your modules or plugins the right order by sorting them with Dependency Sorter.

## How to use
DependencySorter is build as a generic IEnumerable, allowing you to sort any kind of object/type. 

Example with strings:
```
var collection = new DependencyCollection<string>();
collection.Add("test2", "test");
collection.Add("test");

var list = collection.ToList(); // returns ["test", "test2"]
```

Example with types:
```
var collection = new DependencyCollection<Type>();
collection.Add(typeof(UserService), typeof(ConfigurationService));
collection.Add(typeof(ConfigurationService));

var list = collection.ToList(); // returns [ConfigurationService, UserService]
```
