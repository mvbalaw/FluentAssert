FluentAssert ReadMe
==
### Description

Fluent assertions express what you want tested instead of how. For example:

    foo.ShouldBeNull();
    "catalog".ShouldContain("cat");

instead of

    Assert.IsNull(foo);
    Assert.IsTrue("catalog".Contains("cat"));

### Behavior Driven Development Framework	
This project also provides a simple BDD framework that lets you write tests that can be easily understood and verified by non-developers:

    Test.Given(_personRepository)
        .When(save_is_called)
		.With(a_person_without_a_first_name)
        .Should(not_populate_the_id_property_of_the_person)
        .Verify();

    Test.Given(_personRepository)
        .When(save_is_called)
		.With(a_valid_person)
        .Should(save_the_person_data_in_the_database)
        .Should(populate_the_id_property_of_the_person)
        .Verify();

    Test.Verify(
        when_save_is_called,
		with_a_valid_person,
        should_save_the_person_data_in_the_database,
        should_populate_the_id_property_of_the_person
        );
		
![BDD DSL Flow][flow]

### How To Build:

The build script requires Ruby with rake installed.

1. Run `InstallGems.bat` to get the ruby dependencies (only needs to be run once per computer)
1. open a command prompt to the root folder and type `rake` to execute rakefile.rb

If you do not have ruby:

1. You need to create a src\CommonAssemblyInfo.cs file. Go.bat will copy src\CommonAssemblyInfo.cs.default to src\CommonAssemblyInfo.cs
1. open src\StarterTree.sln with Visual Studio and build the solution
		
### License		

[MIT License][mitlicense]

This project is part of [MVBA's Open Source Projects][MvbaLawGithub].

[flow]: https://raw.github.com/mvba/FluentAssert/master/bdd_dsl_flow.png  "BDD DSL Flow"
[MvbaLawGithub]: http://mvbalaw.github.io
[mitlicense]: http://www.opensource.org/licenses/mit-license.php

