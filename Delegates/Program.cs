using Delegates;
using Delegates.Entities;

//  ---------------------- Custom Delegates -----------------------
var customDelegateExamplifier = new CustomDelegateExamplifier();

customDelegateExamplifier.ExecuteExample_1();
customDelegateExamplifier.ExecuteExample_2();
customDelegateExamplifier.ExecuteExample_3((item) => item < 0);

//  ----------------------  Existing Delegates -----------------------

var existingDelegateExamplifier = new ExistingDelegatesExamplifier();

existingDelegateExamplifier.ExecutePredicateExample((item) => item < 0);
existingDelegateExamplifier.ExecuteActionExample((item) => Console.WriteLine($"Executando Action. Item: {item}"));

var result = existingDelegateExamplifier.ExecuteFuncExample((list) =>
{
    var result = new List<int>();
    
    foreach (var number in list)
        result.Add(number * 3);

    return result;
});

Console.Write("Resultado da Func: ");
result.ForEach((item) => Console.Write(item + " "));
