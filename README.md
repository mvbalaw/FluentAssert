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
        .When(Save_fails)
        .Should(Not_populate_the_id_property_of_the_person)
        .Verify();

## License		

MIT License

This project is part of [MVBA Law Commons][mvbalawcommons].

[mvbalawcommons]: http://code.google.com/p/mvbalaw-commons/