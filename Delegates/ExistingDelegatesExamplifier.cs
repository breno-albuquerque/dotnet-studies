namespace Delegates
{
    public class ExistingDelegatesExamplifier
    {
        private List<int> _list1 = new() { 1, 2, -1, -2 };
        private List<int> _list2 = new() { 1, 2, -1, -2 };
    
        //  Utilizando Predicate (Delegate que retorna bool)
        public void ExecutePredicateExample(Predicate<int> predicate)
        {
            Console.WriteLine($"Quantidade de elementos antes: {_list1.Count}");

            var result = new List<int>();

            foreach (var number in _list1)
            {
                if (predicate.Invoke(number) == false)
                    result.Add(number);
            }

            _list1 = result;
        
            Console.WriteLine($"Quantidade de elementos antes: {_list1.Count}");
        }

        //  Utilizando Action (Delegate que retorna void)
        public void ExecuteActionExample(Action<int> action)
        {
            foreach (var number in _list2)
            {
                action.Invoke(number);
            }
        }

        //  Utilizando Func (Delegate que retorna o ÚLTIMO PARÂMETRO genérico)
        public List<int> ExecuteFuncExample(Func<List<int>, List<int>> func)
        {
            return func.Invoke(_list2);
        }
    }
}