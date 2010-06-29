## Fluent NUnit Assertions

Fluent assertions express what you want tested instead of how. For example:

    foo.ShouldBeNull();
    "catalog".ShouldContain("cat");

instead of

    Assert.IsNull(foo);
    Assert.IsTrue("catalog".Contains("cat"));

## Behavior Driven Development Framework	
This project also provides a simple BDD framework that lets you write tests that can be easily understood and verified by non-developers:

    Test.Given(_personRepository)
        .When(Save_is_called)
		.With(A_person_without_a_first_name)
        .Should(Not_populate_the_id_property_of_the_person)
        .Verify();

    Test.Given(_personRepository)
        .When(Save_is_called)
		.With(A_valid_person)
        .Should(Save_the_person_data_in_the_database)
        .Should(Populate_the_id_property_of_the_person)
        .Verify();

![BDD DSL Flow][flow]
		
## License		

[MIT License][mitlicense]

This project is part of [MVBA Law Commons][mvbalawcommons].

[mvbalawcommons]: http://code.google.com/p/mvbalaw-commons/
[mitlicense]: http://www.opensource.org/licenses/mit-license.php
[flow]: /mvba/FluentAssert/raw/master/bdd_dsl_flow.png  "BDD DSL Flow"
